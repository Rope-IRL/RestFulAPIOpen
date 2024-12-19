namespace RestFulAPI.Core.Models;

public class FlatContract
{
    public int Id { get; set; }
    
    public DateOnly StartDate { get; set; }
    
    public DateOnly EndDate { get; set; }
    
    public decimal Cost { get; set; }
    
    public int FlatId { get; set; }
    
    public Flat? Flat { get; set; }
    
    public int LandlordId { get; set; }
    
    public Landlord? Landlord { get; set; }
    
    public int LesseeId { get; set; }
    
    public Lessee? Lessee { get; set; }
}