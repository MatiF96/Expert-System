using ClinicSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Services
{
    public interface IUsersService
    {
        Task<List<UserDto>> GetAll();
        Task<UserDto> Get(int userId);
        Task<UserDto> ChangeRole(int userId, string role);
        Task<int?> Delete(int userId);
        Task<UserDto> EditUser(int userId, EditUserDto editUser);
        Task<List<UserDto>> GetPatients();
    }
}
