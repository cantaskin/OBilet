using Application.Features.Buses.Constants;
using Application.Features.Buses.Rules;
using Application.Features.Personels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Buses.Constants.BusesOperationClaims;

namespace Application.Features.Buses.Commands.Create;

public class CreateBusCommand : IRequest<CreatedBusResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest, ISecuredRequest
{
    public required string NumberPlate { get; set; } 
    public required bool HasOneSeat { get; set; } = false; // Tekli koltuk var m��
    public int DoorGapRowIndex { get; set; } = 7;
    public int DoorGapSize { get; set; } = 1;
    public int Column { get; set; } = 4;
    public int Row { get; set; } = 15;
    public List<int>? PersonelIds { get; set; }
    
    //Personel i�in buraya bir b�l�m ayr�labilir belki ya da personeli kaydetip burada update k�sm�nda yap�labilir. 
    public string[] Roles => [Admin, Write, BusesOperationClaims.Create];
    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBuses"];

    public class CreateBusCommandHandler : IRequestHandler<CreateBusCommand, CreatedBusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusRepository _busRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IPersonelRepository _personelRepository;
        private readonly PersonelBusinessRules _personelBusinessRules;
        private readonly BusBusinessRules _busBusinessRules;

        public CreateBusCommandHandler(IMapper mapper, IBusRepository busRepository,
                                       BusBusinessRules busBusinessRules, ISeatRepository seatRepository, IPersonelRepository personelRepository, PersonelBusinessRules personelBusinessRules)
        {
            _mapper = mapper;
            _busRepository = busRepository;
            _busBusinessRules = busBusinessRules;
            _seatRepository = seatRepository;
            _personelRepository = personelRepository;
            _personelBusinessRules = personelBusinessRules;
        }

        public async Task<CreatedBusResponse> Handle(CreateBusCommand request, CancellationToken cancellationToken)
        {
            Bus bus = _mapper.Map<Bus>(request);
            
            await _busBusinessRules.BusPlateShouldntExistWhenCreated(request.NumberPlate, cancellationToken);
            
            if(request.Row < 1 || request.Row > 30)
                throw new ArgumentOutOfRangeException(nameof(request.Row), "Row must be between 1 and 30.");

            if(request.Column < 1 || request.Column > 4)
                throw new ArgumentOutOfRangeException(nameof(request.Column), "Column must be between 1 and 4.");
                
            if (request.DoorGapRowIndex < 0 || request.DoorGapRowIndex >= request.Row)
                throw new ArgumentOutOfRangeException(nameof(request.DoorGapRowIndex), "DoorGapRowIndex must be between 0 and RowIndex.");

            if(request.DoorGapSize < 1 || request.DoorGapSize > 2)
                throw new ArgumentOutOfRangeException(nameof(request.DoorGapSize), "DoorGapSize must be between 1 and 2.");

            if (request.HasOneSeat && request.Column < 2)
                throw new ArgumentException("If HasOneSeat is true, Column must be greater than 2.", nameof(request.Column));

            if (request.Row / request.Column < 1)
                throw new ArgumentException("Row must be greater than or equal to Column.", nameof(request.Row));



            //await _busBusinessRules.BusPlateShouldntExistWhenCreated(request.NumberPlate,cancellationToken);

            bus = await _busRepository.AddAsync(bus, cancellationToken);

            if (request.PersonelIds != null)
            {

                List<Personel> personelList = new List<Personel>();
                foreach (var personelId in request.PersonelIds)
                {

                    await _personelBusinessRules.PersonelIdShouldExistWhenSelected(personelId, cancellationToken);
                    var personel = await _personelRepository.GetAsync(p => p.Id == personelId, cancellationToken: cancellationToken);

                    personelList.Add(personel);
                }
            }
            

            Seat?[,] seats = new Seat?[request.Row, request.Column];

            int seatNumber = 1;
            for (int row = 0; row < request.Row; row++)
            {
                for (int column = 0; column < request.Column; column++)
                {
                    if (request.HasOneSeat && column == 1 && row != request.Row - 1) // En arkadaki koltuklar hari�, orta bo�luk i�in tekli ise e�er
                    {
                        seats[row, column] = null;
                        continue;
                    }

                    if (column > 1 && (row >= request.DoorGapRowIndex && row <= (request.DoorGapRowIndex + request.DoorGapSize)))
                    {
                        seats[row, column] = null;
                        continue;
                    }

                    seats[row, column] = new Seat()
                    {
                        BusId = bus.Id,
                        LocalSeatId = seatNumber++,
                        CreatedDate = DateTime.Now,
                    };
                }
            }

            List<Seat> seatList = new List<Seat>();

            for (int row = 0; row < request.Row; row++)
            {
                for (int column = 0; column < request.Column; column++)
                {
                    var currentSeat = seats[row, column];
                    if (currentSeat == null)
                        continue;

                    // Solundaki koltuk
                    if (column > 0 && seats[row, column - 1] != null)
                        currentSeat.LeftSeatId = seats[row, column - 1]!.LocalSeatId;

                    // Sa��ndaki koltuk
                    if (column < request.Column - 1 && seats[row, column + 1] != null)
                        currentSeat.RightSeatId = seats[row, column + 1]!.LocalSeatId;

                    // �st�ndeki koltuk
                    if (row > 0 && seats[row - 1, column] != null)
                        currentSeat.TopSeatId = seats[row - 1, column]!.LocalSeatId;

                    // Alt�ndaki koltuk
                    if (row < request.Row - 1 && seats[row + 1, column] != null)
                        currentSeat.BottomSeatId = seats[row + 1, column]!.LocalSeatId;

                    seatList.Add(currentSeat);
                }
            }

            await _seatRepository.AddRangeAsync(seatList, cancellationToken);


            bus.SeatCount = seatList.Count;
            await _busRepository.UpdateAsync(bus, cancellationToken);

            CreatedBusResponse response = _mapper.Map<CreatedBusResponse>(bus);
            return response;
        }
    }
}
