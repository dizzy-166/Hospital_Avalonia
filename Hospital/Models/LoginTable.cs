using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class LoginTable
{
    public int IdLogin { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? IdRole { get; set; }

    public int? IdUser { get; set; }

    public virtual RoleTable? IdRoleNavigation { get; set; }

    public virtual UserTable? IdUserNavigation { get; set; }
}
