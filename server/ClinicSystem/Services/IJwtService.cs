using ClinicSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Services
{
    public interface IJwtService
    {
        string CreateToken(UserDto user);
    }
}
