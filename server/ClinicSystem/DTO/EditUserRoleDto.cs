using System.ComponentModel.DataAnnotations;

namespace ClinicSystem.DTO
{
    public class EditUserRoleDto
    {
        [Required]
        public string Role { get; set; }
    }
}
