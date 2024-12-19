namespace RestFulAPI.Core.Models;

public class RoomContract
{
    public int Id { get; set; }
    
    public DateOnly StartDate { get; set; }
    
    public DateOnly EndDate { get; set; }
    
    public decimal Cost { get; set; }
    
    public int RoomId { get; set; }
    
    public Room? Room { get; set; }
    
    public int LandlordId { get; set; }
    
    public Landlord? Landlord { get; set; }
    
    public int LesseeId { get; set; }
    
    public Lessee? Lessee { get; set; }
}