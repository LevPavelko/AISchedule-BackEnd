using AIScheduleUI5.DAL.EF;
using AIScheduleUI5.DAL.Entities;
using AIScheduleUI5.DAL.Interfaces;

namespace AIScheduleUI5.DAL.Repository
{
    public class ScheduleRepository :  IScheduleRepository
    {
        private ScheduleContext _db;
        public ScheduleRepository(ScheduleContext db)
        {
            _db = db;
        }
    }
}

