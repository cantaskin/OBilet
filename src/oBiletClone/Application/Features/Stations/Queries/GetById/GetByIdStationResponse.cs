using NArchitecture.Core.Application.Responses;

namespace Application.Features.Stations.Queries.GetById;

public class GetByIdStationResponse : IResponse
{
    public int Id { get; set; }

    public string Name { get; set; }
}