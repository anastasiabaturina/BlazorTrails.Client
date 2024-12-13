using BlazorTrails.Shared.Features.ManageTrails.EditTrail;
using BlazorTrails.Shares.Features.ManageTrails.Validations;
using FluentValidation;

namespace BlazorTrails.Shared.Features.ManageTrails.Validations;

public class EditTrailRequestValidator : AbstractValidator<EditTrailRequest>
{
    public EditTrailRequestValidator()
    {
        RuleFor(e => e.Trail).SetValidator(new TrailValidator());
    }
}
