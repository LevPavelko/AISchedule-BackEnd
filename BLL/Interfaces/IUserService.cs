using AIScheduleUI5.BLL.DTOs;
using AIScheduleUI5.DAL.Entities;

namespace AIScheduleUI5.BLL.Interfaces;

public interface IUserService
{
    //Task<List<User>> GetAllAsync();
    //Task<User?> GetByIdAsync(Guid id);
    Task CreateAsync(UserDto userDto);
    //Task<User?> UpdateAsync(User user);
    //Task<bool> DeleteAsync(Guid id);
    Task<UserDto?> GetByEmailAsync(string email);
    Task<bool> UserExistsByEmailAsync(string email);
}

