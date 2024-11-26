namespace RestFulAPI.Core.Models;

public class Room
{
    public int Id { get; set; }
    
    public string Header { get; set; }
    
    public string Description { get; set; }

    public bool IsBathroomAvailable { get; set; }

    public bool IsWiFiAvailable { get; set; }
    
    public decimal CostPerDay { get; set; }
    
    public int HotelId { get; set; }
    
    public Hotel? Hotel { get; set; }
    
    public List<RoomContract>? Contracts { get; set; }
}