using NArchitecture.Core.Application.Responses;

namespace Application.Features.Buses.Commands.Create;

public class CreatedBusResponse : IResponse
{
    public int Id { get; set; }
    public string NumberPlate { get; set; }
}