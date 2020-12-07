using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.DTO
{
    public class EditAppointmentDto
    {
        [Required]
        public DateTime Date { get; set; }
    }
}
