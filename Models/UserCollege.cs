using System;
using System.Collections.Generic;

namespace secondapi.Models;

public partial class UserCollege
{
    public string Email { get; set; } = null!;

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? Type { get; set; }
}
