using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.DTO
{
    public class UserRole
    {
        public static string Patient = "Patient";
        public static string Doctor = "Doctor";
        public static string Admin = "Admin";

        public static bool isUserRole(string role)
        {
            var roles = new List<string>
            {
                Patient, Doctor, Admin
            };
            return roles.Contains(role);
        }
    }
}
