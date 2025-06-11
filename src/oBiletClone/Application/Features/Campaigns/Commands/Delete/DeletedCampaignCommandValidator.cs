using FluentValidation;

namespace Application.Features.Campaigns.Commands.Delete;

public class DeleteCampaignCommandValidator : AbstractValidator<DeleteCampaignCommand>
{
    public DeleteCampaignCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}