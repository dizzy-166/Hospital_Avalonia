using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class PatientAllergy
{
    public int IdAllergy { get; set; }

    public int? IdPatient { get; set; }

    public string AllergyName { get; set; } = null!;

    public string? Severity { get; set; }

    public string? Notes { get; set; }

    public virtual UserTable? IdPatientNavigation { get; set; }
}
