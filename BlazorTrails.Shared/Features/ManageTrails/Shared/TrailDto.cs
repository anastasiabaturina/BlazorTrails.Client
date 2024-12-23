namespace BlazorTrails.Shared.Features.ManageTrails.Shared;

public class TrailDto
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    public string Location { get; set; } = "";

    public string? Image { get; set; }

    public ImageAction ImageAction { get; set; }

    public int TimeInMinutes { get; set; }

    public int Length { get; set; }

    public List<WaypointDto> Waypoints { get; set; } = new List<WaypointDto>();

    public record WaypointDto(decimal Latitude, decimal Longitude);
}

public enum ImageAction
{
    None,
    Add,
    Remove
}