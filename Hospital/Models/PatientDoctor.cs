using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class PatientDoctor
{
    public int IdPatientDoctor { get; set; }

    public int? IdPatient { get; set; }

    public int? IdDoctor { get; set; }

    public DateTime? AssignmentDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual UserTable? IdDoctorNavigation { get; set; }

    public virtual UserTable? IdPatientNavigation { get; set; }

    public virtual ICollection<VisitsTable> VisitsTables { get; set; } = new List<VisitsTable>();
}
