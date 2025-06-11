using NArchitecture.Core.Application.Responses;

namespace Application.Features.Campaigns.Commands.Create;

public class CreatedCampaignResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal DiscountPercentage { get; set; }
    public decimal? DiscountFixedAmount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}