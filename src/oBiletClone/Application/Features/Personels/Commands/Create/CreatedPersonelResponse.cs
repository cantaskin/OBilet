using NArchitecture.Core.Application.Responses;

namespace Application.Features.Personels.Commands.Create;

public class CreatedPersonelResponse : IResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalId { get; set; }
    public bool IsMale { get; set; }
}