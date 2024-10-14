using System;
using System.Collections.Generic;

namespace RestFulAPI;

public partial class HotelsRoom
{
    public int Rid { get; set; }

    public string Header { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal AvgMark { get; set; }

    public decimal CostPerDay { get; set; }

    public int? Hid { get; set; }

}
