namespace BlazorTrails.Shared.Features.ManageTrails.Shared;

public class TrailDto
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    public string Location { get; set; } = "";

    public int TimeInMinutes { get; set; }

    public int Length { get; set; }

    public string? Image { get; set; }

    public ImageAction ImageAct { get; set; }

    public List<RouteInstruction> Route { get; set; } = new List<RouteInstruction>();

    public class RouteInstruction
    {
        public int Stage { get; set; }
        public string Description { get; set; } = "";
    }

    public enum ImageAction
    {
        None,
        Add,
        Remove
    }
}