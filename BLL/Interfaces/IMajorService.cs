using AIScheduleUI5.BLL.DTOs;


namespace AIScheduleUI5.BLL.Interfaces;

public interface IMajorService
{

    Task<List<MajorDto>> GetByUniversityIdAsync(Guid universityId);

}

