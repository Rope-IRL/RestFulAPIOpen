namespace RestFulAPI.Core.Models;

public class Landlord
{
    public int Id { get; set; }

    public string Login { get; set; }
    
    public string HashedPassword { get; set; }
    
    public string Email { get; set; }
    
    public List<Flat>? Flats { get; set; }
    
    public List<FlatContract>? FlatContracts { get; set; }
    
    public List<House>? Houses { get; set; }
    
    public List<HouseContract>? HouseContracts { get; set; }
    
    public List<Hotel>? Hotels { get; set; }
    
    public List<RoomContract>? RoomContracts { get; set; }
    
    public LandlordAdditionalInfo? AdditionalInfo { get; set; }
}