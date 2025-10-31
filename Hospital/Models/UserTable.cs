using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class UserTable
{
    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string FamilyName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateOnly? BirthDate { get; set; }

    public decimal? Height { get; set; }

    public decimal? Weight { get; set; }

    public int? IdGender { get; set; }

    public virtual GenderTable? IdGenderNavigation { get; set; }

    public virtual ICollection<LoginTable> LoginTables { get; set; } = new List<LoginTable>();

    public virtual ICollection<PatientDoctor> PatientDoctorIdDoctorNavigations { get; set; } = new List<PatientDoctor>();

    public virtual ICollection<PatientDoctor> PatientDoctorIdPatientNavigations { get; set; } = new List<PatientDoctor>();

    public virtual ICollection<VisitsTable> VisitsTableIdDoctorNavigations { get; set; } = new List<VisitsTable>();

    public virtual ICollection<VisitsTable> VisitsTableIdUserNavigations { get; set; } = new List<VisitsTable>();

    public virtual ICollection<TraitTable> IdTraits { get; set; } = new List<TraitTable>();
}
