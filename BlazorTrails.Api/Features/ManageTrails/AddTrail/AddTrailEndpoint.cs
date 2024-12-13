using Ardalis.ApiEndpoints;
using BlazorTrails.Api.Persistence;
using Microsoft.AspNetCore.Mvc;
using BlazorTrails.Api.Persistence.Entities;
using BlazorTrails.Shared.Features.ManageTrails.AddTrail;

namespace BlazorTrails.Api.Features.ManageTrails.AddTrail;

public class AddTrailEndpoint : EndpointBaseAsync.WithRequest<AddTrailRequest>.WithActionResult<int>
{
    private readonly BlazingTrailsContext _context;

    public AddTrailEndpoint(BlazingTrailsContext context)
    {
        _context = context;
    }

    [HttpPost(AddTrailRequest.RouteTemplate)]
    public override async Task<ActionResult<int>> HandleAsync(AddTrailRequest request, CancellationToken cancellationToken = default)
    {
        var trail = new Trail
        {
            Name = request.Trail.Name,
            Description = request.Trail.Description,
            Location = request.Trail.Location,
            TimeInMinutes = request.Trail.TimeInMinutes,
            Length = request.Trail.Length,
        };

        _context.Trails.Add(trail);

        var routeInstructions = request.Trail.Route
            .Select(x => new RouteInstruction
            {
                Stage = x.Stage,
                Description = x.Description,
                Trail = trail
            });

        _context.RouteInstructions
            .AddRange(routeInstructions);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(trail.Id);
    }
}
