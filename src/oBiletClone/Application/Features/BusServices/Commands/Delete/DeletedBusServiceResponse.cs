using NArchitecture.Core.Application.Responses;

namespace Application.Features.BusServices.Commands.Delete;

public class DeletedBusServiceResponse : IResponse
{
    public int Id { get; set; }
}