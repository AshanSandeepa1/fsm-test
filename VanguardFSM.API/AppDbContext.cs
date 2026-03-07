using Microsoft.EntityFrameworkCore;
using VanguardFSM.Shared.Models; // Accessing our shared models

namespace VanguardFSM.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // This represents your table in SQL Server
    public DbSet<TaskItem> Tasks => Set<TaskItem>();

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // A test task in London (using Longitude, Latitude)
    modelBuilder.Entity<TaskItem>().HasData(
        new TaskItem { 
            Id = 1, 
            Title = "Repair AC - Customer A", 
            IsCompleted = false,
            Location = new NetTopologySuite.Geometries.Point(-0.1278, 51.5074) { SRID = 4326 } 
        }
    );
}

}
