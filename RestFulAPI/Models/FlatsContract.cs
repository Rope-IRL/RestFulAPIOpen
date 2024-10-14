using System;
using System.Collections.Generic;

namespace RestFulAPI;

public partial class FlatsContract
{
    public int Id { get; set; }

    public int? Lid { get; set; }

    public int? Llid { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal Cost { get; set; }

    public int? Fid { get; set; }

    public override string ToString()
    {
        return $"Id is {Id}, Lid is {Lid}, LLid is {Llid}, Start date is {StartDate}, End date is {EndDate}, Cost: {Cost}, Fid: {Fid}";
    }
}
