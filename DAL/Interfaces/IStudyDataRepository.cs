using AIScheduleUI5.DAL.Entities;

namespace AIScheduleUI5.DAL.Interfaces
{
    public interface IStudyDataRepository
    {
        Task CreateStudyData(StudyData studyData);
        Task<StudyData> GetStudyDataByUserId(Guid userId);
    }
}

