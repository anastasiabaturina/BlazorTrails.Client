using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BlazorTrails.Api.Persistence.Entities;

public class WaypointConfig : IEntityTypeConfiguration<Waypoint>
{
    public void Configure(EntityTypeBuilder<Waypoint> builder)
    {
        builder.Property(x => x.TrailId).IsRequired();
        builder.Property(x => x.Latitude).IsRequired();
        builder.Property(x => x.Longitude).IsRequired();
    }
}
