using NetTopologySuite.Geometries;

namespace VanguardFSM.Shared.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = "Worker"; // Admin, Worker, Customer
    public bool IsAvailable { get; set; } = true;
    
    // The worker's current GPS ping from their mobile app
    public Point? LastKnownLocation { get; set; }
}