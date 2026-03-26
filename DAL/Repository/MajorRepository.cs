using AIScheduleUI5.DAL.EF;
using AIScheduleUI5.DAL.Entities;
using AIScheduleUI5.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AIScheduleUI5.DAL.Repository
{
    public class MajorRepository : IMajorRepository
    {
        private ScheduleContext _db;
        public MajorRepository(ScheduleContext db)
        {
            _db = db;
        }

        public async Task<IQueryable<Major>> GetAll()
        {
            return _db.Majors;
        }
    }

}

