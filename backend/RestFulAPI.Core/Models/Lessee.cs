using System.Text.Json.Serialization;
namespace RestFulAPI.Core.Models;

public class Lessee
{
    public int Id { get; set; }

    public string Login { get; set; }
    
    public string HashedPassword { get; set; }
    
    public string Email { get; set; }
    
    public LesseeAdditionalInfo? AdditionalInfo { get; set; }
    
    [JsonIgnore]
    public List<FlatContract>? FlatContracts { get; set; }
    
    [JsonIgnore]
    public List<HouseContract>? HouseContracts { get; set; }
    
    [JsonIgnore]
    public List<RoomContract>? RoomContracts { get; set; }
}