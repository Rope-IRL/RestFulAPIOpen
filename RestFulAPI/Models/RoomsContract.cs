﻿using System;
using System.Collections.Generic;

namespace RestFulAPI;

public partial class RoomsContract
{
    public int Id { get; set; }

    public int? Lid { get; set; }

    public int? Llid { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal Cost { get; set; }

    public int? Rid { get; set; }
}
