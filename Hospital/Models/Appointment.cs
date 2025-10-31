using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class Appointment
{
    public int IdAppointment { get; set; }

    public int? IdPatient { get; set; }

    public int? IdDoctor { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string? Department { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }

    public virtual UserTable? IdDoctorNavigation { get; set; }

    public virtual UserTable? IdPatientNavigation { get; set; }
}
