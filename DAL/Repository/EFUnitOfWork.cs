using System;
using System.Threading.Tasks;
using AIScheduleUI5.DAL.EF;
using AIScheduleUI5.DAL.Interfaces;

namespace AIScheduleUI5.DAL.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ScheduleContext db;

        private UserRepository? userRepository;
        private UniversityRepository? universityRepository;
        private MajorRepository? majorRepository;
        private StudyDataRepository? studyDataRepository;
        private ScheduleRepository? scheduleRepository;

        public EFUnitOfWork(ScheduleContext context)
        {
            db = context;
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IUniversityRepository Universities
        {
            get
            {
                if (universityRepository == null)
                    universityRepository = new UniversityRepository(db);
                return universityRepository;
            }
        }

        public IMajorRepository Majors
        {
            get
            {
                if (majorRepository == null)
                    majorRepository = new MajorRepository(db);
                return majorRepository;
            }
        }

        public IStudyDataRepository StudyData
        {
            get
            {
                if (studyDataRepository == null)
                    studyDataRepository = new StudyDataRepository(db);
                return studyDataRepository;
            }
        }

        public IScheduleRepository Schedules
        {
            get
            {
                if (scheduleRepository == null)
                    scheduleRepository = new ScheduleRepository(db);
                return scheduleRepository;
            }
        }

        public async Task Save()
        {
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Dispose() => db.Dispose();
    }
}

