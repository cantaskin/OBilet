using NArchitecture.Core.Application.Responses;

namespace Application.Features.Stations.Commands.Create;

public class CreatedStationResponse : IResponse
{
    public int Id { get; set; }
}