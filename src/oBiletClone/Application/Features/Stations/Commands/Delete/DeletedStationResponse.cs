using NArchitecture.Core.Application.Responses;

namespace Application.Features.Stations.Commands.Delete;

public class DeletedStationResponse : IResponse
{
    public int Id { get; set; }
}