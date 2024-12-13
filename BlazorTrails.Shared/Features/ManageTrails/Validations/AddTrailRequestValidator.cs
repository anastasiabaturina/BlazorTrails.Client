using BlazorTrails.Shared.Features.ManageTrails.AddTrail;
using FluentValidation;

namespace BlazorTrails.Shares.Features.ManageTrails.Validations;

public class AddTrailRequestValidator : AbstractValidator<AddTrailRequest>
{
    public AddTrailRequestValidator()
    {
        RuleFor(x => x.Trail).SetValidator(new TrailValidator());
    }
}