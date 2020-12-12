using ClinicSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Services
{
    public interface IAuthService
    {
        Task<UserDto> Register(RegisterDto credentials);
        Task<UserDto> Login(LoginDto credentials);
        Task<bool> UserExists(string username);
        Task<UserDto> GetUserInfo(int userId);
        Task<bool> ChangePassword(int userId, ChangePasswordDto passwordDto);
    }
}
