using NArchitecture.Core.Application.Responses;

namespace Application.Features.Stations.Commands.Update;

public class UpdatedStationResponse : IResponse
{
    public int Id { get; set; }
}