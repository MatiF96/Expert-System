using ClinicSystem.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.DTO
{
    public class AppointmentDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public UserDto Doctor { get; set; }
        [Required]
        public UserDto Patient { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public AppointmentDto(Appointment appointment)
        {
            Id = appointment.AppointmentId;
            Doctor = new UserDto(appointment.AppointmentDoctor);
            Patient = new UserDto(appointment.AppointmentPatient);
            Date = appointment.AppointmentDate;
        }
    }
}
