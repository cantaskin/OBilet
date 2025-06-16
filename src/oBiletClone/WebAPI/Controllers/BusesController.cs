using Application.Features.Buses.Commands.Create;
using Application.Features.Buses.Commands.Delete;
using Application.Features.Buses.Commands.PersonelAssign;
using Application.Features.Buses.Commands.Update;
using Application.Features.Buses.Queries.GetById;
using Application.Features.Buses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedBusResponse>> Add([FromBody] CreateBusCommand command)
    {
        CreatedBusResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }




    // [HttpPut]
    // public async Task<ActionResult<UpdatedBusResponse>> Update([FromBody] UpdateBusCommand command)
    // {
    //     UpdatedBusResponse response = await Mediator.Send(command);

    //     return Ok(response);
    // }


    [HttpPut("Personel-Assign")]
    public async Task<ActionResult<PersonelAssignedBusResponse>> PersonelAssign([FromBody] PersonelAssignBusCommand command)
    {
        PersonelAssignedBusResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedBusResponse>> Delete([FromRoute] int id)
    {
        DeleteBusCommand command = new() { Id = id };

        DeletedBusResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdBusResponse>> GetById([FromRoute] int id)
    {
        GetByIdBusQuery query = new() { Id = id };

        GetByIdBusResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListBusQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBusQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListBusListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}