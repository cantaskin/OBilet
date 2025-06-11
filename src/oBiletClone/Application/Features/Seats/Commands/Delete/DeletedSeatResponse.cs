using NArchitecture.Core.Application.Responses;

namespace Application.Features.Seats.Commands.Delete;

public class DeletedSeatResponse : IResponse
{
    public int Id { get; set; }
}