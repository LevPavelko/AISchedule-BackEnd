using AIScheduleUI5.DAL.Entities;

namespace AIScheduleUI5.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> UserExistsByEmailAsync(string email);
    }
}

