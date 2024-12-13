namespace BlazorTrails.Api.Persistence.Entities;

public class Trail
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string? Image {  get; set; }

    public string Location { get; set; } = default!;

    public int TimeInMinutes { get; set; }

    public int Length { get; set; }

    public ICollection<RouteInstruction> Route { get; set; } = default!;
}
