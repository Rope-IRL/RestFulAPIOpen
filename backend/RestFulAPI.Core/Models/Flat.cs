using System.Text.Json.Serialization;

namespace RestFulAPI.Core.Models;

public class Flat
{ 
    public int Id { get; set; }
    
    public string Header { get; set; }
    
    public string Description { get; set; }
    
    public decimal? AverageMark { get; set; } = 0.0m;

    public string City { get; set; }

    public string Address { get; set; }

    public short NumberOfRooms { get; set; }

    public short NumberOfFloors { get; set; }

    public bool IsBathroomAvailable { get; set; }

    public bool IsWiFiAvailable { get; set; }
    
    public decimal CostPerDay { get; set; }
    
    public int LlId { get; set; }
    
    public Landlord? LandLord { get; set; }
    
    [JsonIgnore]
    public List<FlatContract>? Contracts { get; set; }
}