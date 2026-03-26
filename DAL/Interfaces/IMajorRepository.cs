using AIScheduleUI5.DAL.Entities;

namespace AIScheduleUI5.DAL.Interfaces
{
    public interface IMajorRepository
    {
        Task<IQueryable<Major>> GetAll();
    }
}

