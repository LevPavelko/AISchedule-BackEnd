using AIScheduleUI5.DAL.EF;
using AIScheduleUI5.DAL.Entities;
using AIScheduleUI5.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AIScheduleUI5.DAL.Repository
{
    public class StudyDataRepository : IStudyDataRepository
    {
        private ScheduleContext _db;
        public StudyDataRepository(ScheduleContext db)
        {
            _db = db;
        }

        public async Task CreateStudyData(StudyData studyData)
        {
            await _db.AddAsync(studyData);
            await _db.SaveChangesAsync();

        }

        public async Task<StudyData> GetStudyDataByUserId(Guid userId)
        {
            return await _db.StudyData.FirstOrDefaultAsync(s => s.UserId == userId);
        }
    }
}
