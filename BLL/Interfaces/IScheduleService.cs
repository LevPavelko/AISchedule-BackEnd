using AIScheduleUI5.DAL.Entities;

namespace AIScheduleUI5.BLL.Interfaces;

public interface IScheduleService
{
    Task<List<Schedule>> GetAllAsync();
    Task<Schedule?> GetByIdAsync(Guid id);
    Task<List<Schedule>> GetByUserIdAsync(Guid userId);
    Task<Schedule> CreateAsync(Schedule schedule);
    Task<Schedule?> UpdateAsync(Schedule schedule);
    Task<bool> DeleteAsync(Guid id);
}

