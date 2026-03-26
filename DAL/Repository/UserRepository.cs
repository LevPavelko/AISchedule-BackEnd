using System;
using AIScheduleUI5.DAL.EF;
using AIScheduleUI5.DAL.Entities;
using AIScheduleUI5.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AIScheduleUI5.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private ScheduleContext _db;
        public UserRepository(ScheduleContext db)
        {
            _db = db;
        }


        public async Task CreateAsync(User user)
        {
            await _db.Users.AddAsync(user);
        }
        public Task<User?> GetByEmailAsync(string email)
        {
            return _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> UserExistsByEmailAsync(string email)
        {
            return await _db.Users.AnyAsync(u => u.Email == email);
        }

    }


}

