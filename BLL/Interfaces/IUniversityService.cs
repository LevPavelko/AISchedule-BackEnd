using AIScheduleUI5.BLL.DTOs;
using AIScheduleUI5.DAL.Entities;

namespace AIScheduleUI5.BLL.Interfaces;

public interface IUniversityService
{
    Task<IEnumerable<UniversityDto>> GetAllAsync();
    //Task<University?> GetByIdAsync(Guid id);
    //Task<University> CreateAsync(University university);
    //Task<University?> UpdateAsync(University university);
    //Task<bool> DeleteAsync(Guid id);
}

