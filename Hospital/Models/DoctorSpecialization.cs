using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class DoctorSpecialization
{
    public int IdSpecialization { get; set; }

    public int? IdDoctor { get; set; }

    public string Specialization { get; set; } = null!;

    public virtual UserTable? IdDoctorNavigation { get; set; }
}
