using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicSystem.Database
{
    public partial class Account
    {
        public Account()
        {
            AppointmentAppointmentDoctors = new HashSet<Appointment>();
            AppointmentAppointmentPatients = new HashSet<Appointment>();
        }

        public int AccountId { get; set; }
        public string AccountType { get; set; }
        public string AccountLogin { get; set; }
        public string AccountPassword { get; set; }
        public string AccountFullname { get; set; }
        public DateTime? AccountBirthdate { get; set; }

        public virtual ICollection<Appointment> AppointmentAppointmentDoctors { get; set; }
        public virtual ICollection<Appointment> AppointmentAppointmentPatients { get; set; }
    }
}
