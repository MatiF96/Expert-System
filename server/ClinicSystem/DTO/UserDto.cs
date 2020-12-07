using ClinicSystem.Database;
using ClinicSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.DTO
{
    public class UserDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Fullname { get; set; }
        public DateTime? Birthdate { get; set; }

        [Required]
        public string AccountType { get; set; }

        public UserDto(Account account)
        {
            Id = account.AccountId;
            Login = account.AccountLogin;
            var rsa = new RSAHandler();
            Fullname = rsa.Decrypt(account.AccountFullname);
            Birthdate = account.AccountBirthdate;
            AccountType = account.AccountType;
        }
    }
}
