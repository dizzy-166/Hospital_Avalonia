using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class TreatmentCourse
{
    public int IdTreatment { get; set; }

    public int? IdVisit { get; set; }

    public string TreatmentDescription { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Status { get; set; }

    public virtual VisitsTable? IdVisitNavigation { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
