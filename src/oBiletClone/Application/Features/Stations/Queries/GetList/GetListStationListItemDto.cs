using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Stations.Queries.GetList;

public class GetListStationListItemDto : IDto
{
    public int Id { get; set; }

    public string Name { get; set; }
}