using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Seats.Commands.Create;

public class CreatedSeatResponse : IResponse
{
    public int Id { get; set; }
    public int BusId { get; set; }
}