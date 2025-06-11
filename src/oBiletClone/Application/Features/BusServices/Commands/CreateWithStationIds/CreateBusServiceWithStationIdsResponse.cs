using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.BusServices.Commands.CreateWithStationIds;

public class CreateBusServiceWithStationIdsResponse : IResponse
{
    public int Id { get; set; }
}