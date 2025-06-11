using Application.Features.Campaigns.Commands.Create;
using Application.Features.Campaigns.Commands.Delete;
using Application.Features.Campaigns.Commands.Update;
using Application.Features.Campaigns.Queries.GetById;
using Application.Features.Campaigns.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CampaignsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCampaignResponse>> Add([FromBody] CreateCampaignCommand command)
    {
        CreatedCampaignResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCampaignResponse>> Update([FromBody] UpdateCampaignCommand command)
    {
        UpdatedCampaignResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCampaignResponse>> Delete([FromRoute] int id)
    {
        DeleteCampaignCommand command = new() { Id = id };

        DeletedCampaignResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCampaignResponse>> GetById([FromRoute] int id)
    {
        GetByIdCampaignQuery query = new() { Id = id };

        GetByIdCampaignResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListCampaignQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCampaignQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCampaignListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}