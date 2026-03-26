using AIScheduleUI5.BLL.DTOs;


namespace AIScheduleUI5.BLL.Interfaces;

public interface IStudyDataService
{

    Task CreateAsync(StudyDataDto studyData);
    Task<StudyDataDto> GetStudyDataByUserId(Guid userId);
}

