using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace secondapi.Models;

public partial class Bookuserhritik
{
    
    public string? Uname { get; set; }

    public int Uid { get; set; }

    public string? Password { get; set; }
}
