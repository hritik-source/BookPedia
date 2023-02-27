using System;
using System.Collections.Generic;

namespace secondapi.Models;

public partial class Team
{
    public int? Id { get; set; }

    public string TeamName { get; set; } = null!;

    public string? TeamLead { get; set; }

    public virtual ICollection<Emp> Emps { get; } = new List<Emp>();
}
