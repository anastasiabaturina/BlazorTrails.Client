using Ardalis.ApiEndpoints;
using BlazorTrails.Api.Persistence;
using BlazorTrails.Api.Persistence.Entities;
using BlazorTrails.Shared.Features.ManageTrails.EditTrail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorTrails.Api.Features.ManageTrails.EditTrail;

public class EditTrailEndpoint : EndpointBaseAsync.WithRequest<EditTrailRequest>.WithActionResult<bool>
{
    private readonly BlazingTrailsContext _context;

    public EditTrailEndpoint(BlazingTrailsContext context)
    {
        _context = context;
    }

    [HttpPut(EditTrailRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditTrailRequest request, CancellationToken cancellationToken = default)
    {
        var trail = await _context.Trails
           .Include(t => t.Route)
           .FirstOrDefaultAsync(t => t.Id == request.Trail.Id, cancellationToken);

        if (trail is null)
        {
            return BadRequest("Trail could not be found.");
        }

        trail.Id = request.Trail.Id;
        trail.Name = request.Trail.Name;
        trail.Location = request.Trail.Location;
        trail.Image = request.Trail.Image;
        trail.TimeInMinutes = request.Trail.TimeInMinutes;
        trail.Length = request.Trail.Length;
        trail.Description = request.Trail.Description;
        trail.Route = request.Trail.Route.Select(ri => new RouteInstruction
        {
            Stage = ri.Stage, 
            Description = ri.Description,
            Trail = trail
        }).ToList();

       if(request.Trail.ImageAct == BlazorTrails.Shared.Features.ManageTrails.Shared.TrailDto.ImageAction.Remove)
        {
            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", trail.Image!));
            trail.Image = null;
        }

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(true);
    }
}
}
