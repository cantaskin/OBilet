
using Application.Features.BusServices.Commands.CreateWithStationIds;
using Application.Features.BusServices.Commands.Delete;
using Application.Features.BusServices.Commands.Update;
using Application.Features.BusServices.Queries.GetById;
using Application.Features.BusServices.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusServicesController : BaseController
{


    //Bir tane daha create ekle buraya....

    [HttpPost]
    public async Task<ActionResult<CreateBusServiceWithStationIdsResponse>> Add([FromBody] CreateBusServiceWithStationIdsCommand command)
    {
        CreateBusServiceWithStationIdsResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedBusServiceResponse>> Update([FromBody] UpdateBusServiceCommand command)
    {
        UpdatedBusServiceResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedBusServiceResponse>> Delete([FromRoute] int id)
    {
        DeleteBusServiceCommand command = new() { Id = id };

        DeletedBusServiceResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdBusServiceResponse>> GetById([FromRoute] int id)
    {
        GetByIdBusServiceQuery query = new() { Id = id };

        GetByIdBusServiceResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListBusServiceQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBusServiceQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListBusServiceListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}