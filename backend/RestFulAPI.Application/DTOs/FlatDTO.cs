namespace RestFulAPI.Application.DTOs;

public class FlatDTO
{
    public int Id { get; set; }
    
    public string Header { get; set; }
    
    public string Description { get; set; }
    
    public decimal AverageMark { get; set; }

    public string City { get; set; }

    public string Address { get; set; }

    public short NumberOfRooms { get; set; }

    public short NumberOfFloors { get; set; }

    public bool IsBathroomAvailable { get; set; }

    public bool IsWiFiAvailable { get; set; }
    
    public decimal CostPerDay { get; set; }
    
    public int LlId { get; set; }
}