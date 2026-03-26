using AIScheduleUI5.BLL.Interfaces;
using AIScheduleUI5.DAL.Entities;
using AIScheduleUI5.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AIScheduleUI5.BLL.Services;

public sealed class ScheduleService(IUnitOfWork uow) : IScheduleService
{
    public Task<List<Schedule>> GetAllAsync() =>
        uow.Schedules.Query().AsNoTracking().ToListAsync();

    public Task<Schedule?> GetByIdAsync(Guid id) =>
        uow.Schedules.Query().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public Task<List<Schedule>> GetByUserIdAsync(Guid userId) =>
        uow.Schedules.Query().AsNoTracking().Where(x => x.UserId == userId).ToListAsync();

    public async Task<Schedule> CreateAsync(Schedule schedule)
    {
        if (schedule.Id == Guid.Empty) schedule.Id = Guid.NewGuid();
        await uow.Schedules.AddAsync(schedule);
        await uow.Save();
        return schedule;
    }

    public async Task<Schedule?> UpdateAsync(Schedule schedule)
    {
        var exists = await uow.Schedules.AnyAsync(x => x.Id == schedule.Id);
        if (!exists) return null;

        uow.Schedules.Update(schedule);
        await uow.Save();
        return schedule;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await uow.Schedules.GetByIdAsync(id);
        if (entity is null) return false;

        uow.Schedules.Remove(entity);
        await uow.Save();
        return true;
    }
}

