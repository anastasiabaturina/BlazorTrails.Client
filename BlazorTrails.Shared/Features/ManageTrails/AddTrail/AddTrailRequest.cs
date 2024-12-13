using BlazorTrails.Shared.Features.ManageTrails.Shared;
using MediatR;

namespace BlazorTrails.Shared.Features.ManageTrails.AddTrail;

public record AddTrailRequest(TrailDto Trail) : IRequest<AddTrailRequest.Response>
{
    public const string RouteTemplate = "/api/trails";

    public record Response(int TrailId);
}

