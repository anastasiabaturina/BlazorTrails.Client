using Ardalis.ApiEndpoints;
using BlazorTrails.Api.Persistence;
using Microsoft.AspNetCore.Mvc;
using BlazorTrails.Api.Persistence.Entities;
using BlazorTrails.Shared.Features.ManageTrails.AddTrail;

namespace BlazorTrails.Api.Features.ManageTrails.AddTrail;

public class AddTrailEndpoint : EndpointBaseAsync.WithRequest<AddTrailRequest>.WithActionResult<int>
{
    private readonly BlazingTrailsContext _database;

    public AddTrailEndpoint(BlazingTrailsContext database)
    {
        _database = database;
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
            Waypoints = request.Trail.Waypoints.Select(wp => new Waypoint
            {
                Latitude = wp.Latitude,
                Longitude = wp.Longitude
            }).ToList()
        };

        await _database.Trails.AddAsync(trail, cancellationToken);
        await _database.SaveChangesAsync(cancellationToken);

        return Ok(trail.Id);
    }
}
