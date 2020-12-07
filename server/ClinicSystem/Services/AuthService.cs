using ClinicSystem.Database;
using ClinicSystem.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly ClinicDbContext _ctx;
        private readonly IPasswordService _passwordService;
        public AuthService(ClinicDbContext ctx, IPasswordService passwordService)
        {
            _ctx = ctx;
            _passwordService = passwordService;
        }

        public async Task<UserDto> GetUserInfo(int userId)
        {
            var account = await _ctx.Accounts.FindAsync(userId);
            if (account == null) return null;
            return new UserDto(account);
        }

        public async Task<UserDto> Login(LoginDto credentials)
        {
            var account = await _ctx.Accounts.SingleOrDefaultAsync(account => account.AccountLogin == credentials.Login);
            if (account == null || !_passwordService.IsHashEqual(credentials.Password, account.AccountPassword))
            {
                return null;
            }
            return new UserDto(account);
        }

        public async Task<UserDto> Register(RegisterDto credentials)
        {
            var user = new Account
            {
                AccountLogin = credentials.Login,
                AccountPassword = _passwordService.Hash(credentials.Password),
                AccountBirthdate = credentials.Birthdate,
                AccountFullname = _passwordService.Hash(credentials.Fullname),
                AccountType = UserRole.Patient
            };
            var result = await _ctx.Accounts.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return new UserDto(result.Entity);
        }

        public Task<bool> UserExists(string username)
        {
            return  _ctx.Accounts.AnyAsync(acc => acc.AccountLogin == username);
        }
    }
}
