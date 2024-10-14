using System;
using System.Collections.Generic;

namespace RestFulAPI;

public partial class LandLord
{
    public int Llid { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

}
