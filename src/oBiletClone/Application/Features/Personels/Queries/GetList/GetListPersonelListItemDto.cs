using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Personels.Queries.GetList;

public class GetListPersonelListItemDto : IDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalId { get; set; }
    public bool IsMale { get; set; }
}