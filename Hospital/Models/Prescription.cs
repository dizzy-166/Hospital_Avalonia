using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class Prescription
{
    public int IdPrescription { get; set; }

    public int? IdTreatment { get; set; }

    public string MedicationName { get; set; } = null!;

    public string? Dosage { get; set; }

    public string? Frequency { get; set; }

    public int? DurationDays { get; set; }

    public virtual TreatmentCourse? IdTreatmentNavigation { get; set; }
}
