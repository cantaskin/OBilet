using NArchitecture.Core.Application.Responses;

namespace Application.Features.BusServiceStations.Commands.Delete;

public class DeletedBusServiceStationResponse : IResponse
{
    public int Id { get; set; }
}