using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class DiagnosisTable
{
    public int IdDiagnosis { get; set; }

    public string DiagnosisName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<VisitsTable> VisitsTables { get; set; } = new List<VisitsTable>();
}
