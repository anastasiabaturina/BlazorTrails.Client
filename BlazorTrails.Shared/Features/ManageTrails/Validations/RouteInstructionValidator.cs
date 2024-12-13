using BlazorTrails.Shared.Features.ManageTrails.Shared;
using FluentValidation;

namespace BlazorTrails.Shares.Features.ManageTrails.Validations;

public class RouteInstructionValidator : AbstractValidator<TrailDto.RouteInstruction>
{
    public RouteInstructionValidator()
    {
        RuleFor(x => x.Stage).NotEmpty().WithMessage("Please enter a stage");

        RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter a description");
    }
}

