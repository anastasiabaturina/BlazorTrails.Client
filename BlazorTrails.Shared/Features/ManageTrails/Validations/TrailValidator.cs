﻿using BlazorTrails.Shared.Features.ManageTrails.Shared;
using FluentValidation;

namespace BlazorTrails.Shares.Features.ManageTrails.Validations;

public class TrailValidator : AbstractValidator<TrailDto>
{
    public TrailValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter a name");

        RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter a description");

        RuleFor(x => x.Location).NotEmpty().WithMessage("Please enter a location");

        RuleFor(x => x.TimeInMinutes).GreaterThan(0).WithMessage("Please enter a time");

        RuleFor(x => x.Length).GreaterThan(0).WithMessage("Please enter a length");

        RuleFor(x => x.Waypoints).NotEmpty().WithMessage("Please add a waypoint");
    }
}