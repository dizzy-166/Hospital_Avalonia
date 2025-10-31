using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class TraitTable
{
    public int IdTrait { get; set; }

    public string Trait { get; set; } = null!;

    public virtual ICollection<UserTable> IdUsers { get; set; } = new List<UserTable>();
}
