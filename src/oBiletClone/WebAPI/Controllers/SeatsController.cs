using Application.Features.Seats.Commands.Create;
using Application.Features.Seats.Commands.Delete;
using Application.Features.Seats.Commands.Update;
using Application.Features.Seats.Queries.GetById;
using Application.Features.Seats.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Seats.Queries.GetByBusId;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeatsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSeatResponse>> Add([FromBody] CreateSeatCommand command)
    {
        CreatedSeatResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSeatResponse>> Update([FromBody] UpdateSeatCommand command)
    {
        UpdatedSeatResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSeatResponse>> Delete([FromRoute] int id)
    {
        DeleteSeatCommand command = new() { Id = id };

        DeletedSeatResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSeatResponse>> GetById([FromRoute] int id)
    {
        GetByIdSeatQuery query = new() { Id = id };

        GetByIdSeatResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("ByBusId/{id}")]
    public async Task<ActionResult<GetListByBusIdSeatQuery>> GetByBusId([FromQuery] PageRequest pageRequest, [FromRoute] int id)
    {
        GetListByBusIdSeatQuery query = new() { BusId = id, PageRequest = pageRequest};

        var response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSeatQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSeatQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSeatListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}