using NArchitecture.Core.Application.Responses;

namespace Application.Features.Buses.Commands.Update;

public class UpdatedBusResponse : IResponse
{
    public int Id { get; set; }
    public string NumberPlate { get; set; }
    public int SeatCount { get; set; }
    public bool HasOneSeat { get; set; }
}