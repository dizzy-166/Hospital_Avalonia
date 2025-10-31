using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class GenderTable
{
    public int IdGender { get; set; }

    public string Gender { get; set; } = null!;

    public virtual ICollection<UserTable> UserTables { get; set; } = new List<UserTable>();
}
