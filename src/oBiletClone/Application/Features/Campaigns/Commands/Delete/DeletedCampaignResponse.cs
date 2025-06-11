using NArchitecture.Core.Application.Responses;

namespace Application.Features.Campaigns.Commands.Delete;

public class DeletedCampaignResponse : IResponse
{
    public int Id { get; set; }
}