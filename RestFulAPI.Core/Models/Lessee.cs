namespace RestFulAPI.Core.Models;

public class Lessee
{
    public int Id { get; set; }

    public string Login { get; set; }
    
    public string HashedPassword { get; set; }
    
    public string Email { get; set; }
    
    public LesseeAdditionalInfo AdditionalInfo { get; set; }
    
    public List<FlatContract>? FlatContracts { get; set; }
    
    public List<HouseContract>? HouseContracts { get; set; }
    
    public List<RoomContract>? RoomContracts { get; set; }
}