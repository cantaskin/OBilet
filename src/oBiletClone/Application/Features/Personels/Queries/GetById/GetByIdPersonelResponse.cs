using NArchitecture.Core.Application.Responses;

namespace Application.Features.Personels.Queries.GetById;

public class GetByIdPersonelResponse : IResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalId { get; set; }
    public bool IsMale { get; set; }
}