using Application.Features.Stations.Commands.Create;
using Application.Features.Stations.Commands.Delete;
using Application.Features.Stations.Commands.Update;
using Application.Features.Stations.Queries.GetById;
using Application.Features.Stations.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StationsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedStationResponse>> Add([FromBody] CreateStationCommand command)
    {
        CreatedStationResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedStationResponse>> Update([FromBody] UpdateStationCommand command)
    {
        UpdatedStationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedStationResponse>> Delete([FromRoute] int id)
    {
        DeleteStationCommand command = new() { Id = id };

        DeletedStationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdStationResponse>> GetById([FromRoute] int id)
    {
        GetByIdStationQuery query = new() { Id = id };

        GetByIdStationResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListStationQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStationQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListStationListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}