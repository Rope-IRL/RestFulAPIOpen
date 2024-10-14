using System;
using System.Collections.Generic;

namespace RestFulAPI;

public partial class Lessee
{
    public int Lid { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

}
