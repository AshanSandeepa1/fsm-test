using Microsoft.EntityFrameworkCore;
using VanguardFSM.Shared.Models; // Accessing our shared models
using VanguardFSM.Shared.Enums;

namespace VanguardFSM.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

    // This represents your table in SQL Server
    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    public DbSet<User> Users { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<TaskItem>().HasData(
        new TaskItem { 
            Id = 1, 
            Title = "Repair AC - Customer A", 
            Description = "Standard maintenance and filter change.",
            Status = VanguardFSM.Shared.Enums.ServiceStatus.Incoming,
            Location = new NetTopologySuite.Geometries.Point(-0.1278, 51.5074) { SRID = 4326 } 
        }
    );
}

}
