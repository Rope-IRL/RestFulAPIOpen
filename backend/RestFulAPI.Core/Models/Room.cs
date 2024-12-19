using System.Text.Json.Serialization;
namespace RestFulAPI.Core.Models;

public class Room
{
    public int Id { get; set; }

    public string Header { get; set; }

    public string Description { get; set; }

    public decimal? AverageMark { get; set; } = 0.0m;

    public short NumberOfRooms { get; set; }

    public short NumberOfFloors { get; set; }

    public bool IsBathroomAvailable { get; set; }

    public bool IsWiFiAvailable { get; set; }

    public decimal CostPerDay { get; set; }

    public int HotelId { get; set; }
    
    [JsonIgnore]
    public Hotel? Hotel { get; set; }
    
    [JsonIgnore]
    public List<RoomContract>? Contracts { get; set; }
}