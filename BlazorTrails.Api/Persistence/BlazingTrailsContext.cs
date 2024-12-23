using BlazorTrails.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorTrails.Api.Persistence;

public class BlazingTrailsContext : DbContext
{
    public DbSet<Trail> Trails => Set<Trail>();
    public DbSet<Waypoint> Waypoints => Set<Waypoint>();

    public BlazingTrailsContext(DbContextOptions<BlazingTrailsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new TrailConfig());
        modelBuilder.ApplyConfiguration(new WaypointConfig());
    }
}