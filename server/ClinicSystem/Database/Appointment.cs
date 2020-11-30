using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicSystem.Database
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public int AppointmentDoctorId { get; set; }
        public int AppointmentPatientId { get; set; }
        public DateTime AppointmentDate { get; set; }

        public virtual Account AppointmentDoctor { get; set; }
        public virtual Account AppointmentPatient { get; set; }
    }
}
