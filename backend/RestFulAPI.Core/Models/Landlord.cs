using System.Text.Json.Serialization;

namespace RestFulAPI.Core.Models;

public class Landlord
{
    public int Id { get; set; }

    public string Login { get; set; }
    
    public string HashedPassword { get; set; }
    
    public string Email { get; set; }

    [JsonIgnore]
    public List<Flat>? Flats { get; set; }
    
    [JsonIgnore]
    public List<FlatContract>? FlatContracts { get; set; }

    [JsonIgnore]
    public List<House>? Houses { get; set; }
    
    [JsonIgnore]
    public List<HouseContract>? HouseContracts { get; set; }

    [JsonIgnore]
    
    public List<Hotel>? Hotels { get; set; }
    
    [JsonIgnore]
    public List<RoomContract>? RoomContracts { get; set; }
    
    public LandlordAdditionalInfo? AdditionalInfo { get; set; }
}