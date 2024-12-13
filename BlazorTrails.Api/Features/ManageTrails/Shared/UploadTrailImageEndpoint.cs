using Ardalis.ApiEndpoints;
using BlazorTrails.Api.Persistence;
using BlazorTrails.Shared.Features.ManageTrails.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BlazorTrails.Api.Features.ManageTrails.Shared;

public class UploadTrailImageEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<string>
{
    private readonly BlazingTrailsContext _context;

    public UploadTrailImageEndpoint(BlazingTrailsContext context)
    {
        _context = context;
    }

    [HttpPost(UploadTrailImageRequest.RouteTemplate)]
    public override async Task<ActionResult<string>> HandleAsync([FromRoute] int trailId, CancellationToken cancellationToken = default)
    {
        var trail = await _context.Trails.FirstOrDefaultAsync(t => t.Id == trailId, cancellationToken);

        if (trail is null)
        {
            return BadRequest("Trail does not exist.");
        }

        var file = Request.Form.Files[0];

        if (file.Length == 0)
        {
            return BadRequest("No image found");
        }

        var filename = $"{Guid.NewGuid()}.jpg";
        var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

        var resizeOption = new ResizeOptions
        {
            Mode = ResizeMode.Pad,
            Size = new Size(640, 426)
        };

        using var image = Image.Load(file.OpenReadStream());

        image.Mutate(i => i.Resize(resizeOption));

        await image.SaveAsJpegAsync(saveLocation, cancellationToken: cancellationToken);

        if (!string.IsNullOrEmpty(trail.Image))
        {
            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", trail.Image));
        }

        trail.Image = filename;

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(trail.Image);
    }
}
