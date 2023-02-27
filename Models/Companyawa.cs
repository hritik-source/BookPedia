using System;
using System.Collections.Generic;

namespace secondapi.Models;

public partial class Companyawa
{
    public string Cid { get; set; } = null!;

    public string? Cname { get; set; }

    public virtual ICollection<Flightawa> Flightawas { get; } = new List<Flightawa>();
}
