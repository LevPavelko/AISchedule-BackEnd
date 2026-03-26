using System.Runtime.CompilerServices;
using AIScheduleUI5.DAL.EF;
using AIScheduleUI5.DAL.Entities;
using AIScheduleUI5.DAL.Interfaces;

namespace AIScheduleUI5.DAL.Repository
{
    public class UniversityRepository : IUniversityRepository
    {
        private ScheduleContext _db;
        public UniversityRepository(ScheduleContext db)
        {
            _db = db;

        }

        public async Task<IQueryable<University>> GetAll()
        {
            return _db.Universities;
        }
    }
}

