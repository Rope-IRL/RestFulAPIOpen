namespace RestFulAPI.Core.Models;

public class LesseeAdditionalInfo
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public DateOnly BirthDate { get; set; }

    public string Telephone { get; set; }

    public string PassportId { get; set; }

    public decimal AverageMark { get; set; }
    
    public int LesseeId {get; set;}
    
    public Lessee? Lessee {get; set;}
}