using ClinicSystem.Database;
using ClinicSystem.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Services
{
    public class UsersService : IUsersService
    {
        private readonly ClinicDbContext _ctx;

        public UsersService(ClinicDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<UserDto> ChangeRole(int userId, string role)
        {
            var account = await _ctx.Accounts.FindAsync(userId);
            if (account == null) return null;
            account.AccountType = role;
            var changedAccount = _ctx.Accounts.Update(account);
            await _ctx.SaveChangesAsync();
            return new UserDto(changedAccount.Entity);
        }

        public async Task<int?> Delete(int userId)
        {
            var account = await _ctx.Accounts.FindAsync(userId);
            if (account == null) return null;
            _ctx.Accounts.Remove(account);
            await _ctx.SaveChangesAsync();
            return account.AccountId;
        }

        public async Task<UserDto> EditUserDto(int userId, EditUserDto editUser)
        {

            var account = await _ctx.Accounts.FindAsync(userId);
            if (account == null) return null;
            if (!string.IsNullOrEmpty(editUser.Fullname))
            {
                account.AccountFullname = editUser.Fullname;
            }
            if (editUser.Birthdate != null)
            {
                account.AccountBirthdate = editUser.Birthdate;
            }
            var changedAccount = _ctx.Accounts.Update(account);
            return new UserDto(changedAccount.Entity);
        }

        public async Task<UserDto> Get(int userId)
        {
            var account = await _ctx.Accounts.FindAsync(userId);
            if (account == null) return null;
            return new UserDto(account);
        }

        public async Task<List<UserDto>> GetAll()
        {
            List<Account> users = await _ctx.Accounts.ToListAsync();
            return users.Select(u => new UserDto(u)).ToList();
        }

    }
}
