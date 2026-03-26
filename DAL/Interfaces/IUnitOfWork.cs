using System;
using System.Threading.Tasks;

namespace AIScheduleUI5.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IUniversityRepository Universities { get; }
        IMajorRepository Majors { get; }
        IStudyDataRepository StudyData { get; }
        IScheduleRepository Schedules { get; }

        Task Save();
    }
}

