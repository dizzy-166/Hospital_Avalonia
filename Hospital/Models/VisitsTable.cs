using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class VisitsTable
{
    public int IdVisit { get; set; }

    public int? IdUser { get; set; }

    public int? IdDiagnosis { get; set; }

    public int? IdDoctor { get; set; }

    public DateTime? VisitDate { get; set; }

    public string? Notes { get; set; }

    public virtual DiagnosisTable? IdDiagnosisNavigation { get; set; }

    public virtual UserTable? IdDoctorNavigation { get; set; }

    public virtual UserTable? IdUserNavigation { get; set; }
}
