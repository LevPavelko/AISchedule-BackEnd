using AIScheduleUI5.BLL.DTOs;
using AIScheduleUI5.BLL.Interfaces;
using AIScheduleUI5.DAL.Entities;
using AIScheduleUI5.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AIScheduleUI5.BLL.Services;

public sealed class UserService(IUnitOfWork uow) : IUserService
{
    //public Task<List<User>> GetAllAsync() =>
    //    uow.Users.AsNoTracking().ToListAsync();

    //public Task<User?> GetByIdAsync(Guid id) =>
    //    uow.Users.Query().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    //public async Task<User> CreateAsync(User user)
    //{
    //    if (user.Id == Guid.Empty) user.Id = Guid.NewGuid();
    //    await uow.Users.AddAsync(user);
    //    await uow.Save();
    //    return user;
    //}

    //public async Task<User?> UpdateAsync(User user)
    //{
    //    var exists = await uow.Users.AnyAsync(x => x.Id == user.Id);
    //    if (!exists) return null;

    //    uow.Users.Update(user);
    //    await uow.Save();
    //    return user;
    //}

    //public async Task<bool> DeleteAsync(Guid id)
    //{
    //    var entity = await uow.Users.GetByIdAsync(id);
    //    if (entity is null) return false;

    //    uow.Users.Remove(entity);
    //    await uow.Save();
    //    return true;
    //}

    public async Task<UserDto?> GetByEmailAsync(string email)
    {
        User user = await uow.Users.GetByEmailAsync(email);
        if (user == null)
            return null;
        UserDto userDto = new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password

        };
        return userDto;
    }

    public async Task CreateAsync(UserDto userDto)
    {
        var user = new User
        {
            Id = userDto.Id,
            Name = userDto.Name,
            Email = userDto.Email,
            Password = userDto.Password
        };
        await uow.Users.CreateAsync(user);
        await uow.Save();
    }

    public async Task<bool> UserExistsByEmailAsync(string email)
    {
        return await uow.Users.UserExistsByEmailAsync(email);

    }
}

