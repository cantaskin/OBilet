using NArchitecture.Core.Application.Responses;

namespace Application.Features.Buses.Commands.Delete;

public class DeletedBusResponse : IResponse
{
    public int Id { get; set; }
}