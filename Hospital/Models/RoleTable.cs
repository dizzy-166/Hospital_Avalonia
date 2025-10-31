using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class RoleTable
{
    public int IdRole { get; set; }

    public string Role { get; set; } = null!;

    public virtual ICollection<LoginTable> LoginTables { get; set; } = new List<LoginTable>();
}
