namespace RestFulAPI.Core.Models;

public class Hotel
{
    public int Id { get; set; }
    
    public string Header { get; set; }
    
    public string Description { get; set; }
    
    public decimal AverageMark { get; set; }
    
    public string City { get; set; }
    
    public string Address { get; set; }

    public bool IsRestraintAvailable { get; set; }
    
    public bool IsElevatorAvailable { get; set; } 
    
    public int LlId { get; set; }
    
    public Landlord? LandLord { get; set; }
    
    public List<Room>? HotelRooms { get; set; }
    
}