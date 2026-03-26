using AIScheduleUI5.BLL.DTOs;
using AIScheduleUI5.BLL.Interfaces;
using AIScheduleUI5.DAL.Entities;
using AIScheduleUI5.DAL.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AIScheduleUI5.BLL.Services;

public class StudyDataService : IStudyDataService
{
    IUnitOfWork Database { get; set; }
    IMapper _mapper;
    public StudyDataService(IUnitOfWork database, IMapper mapper)
    {
        Database = database;
        _mapper = mapper;
    }
    public async Task CreateAsync(StudyDataDto studyDataDto)
    {
        try
        {
            StudyData studyData = new StudyData
            {
                Id = Guid.NewGuid(),
                UserId = studyDataDto.UserId,
                UniId = studyDataDto.UniId,
                MajorId = studyDataDto.MajorId,
                Semester = studyDataDto.Semester,
            };

            await Database.StudyData.CreateStudyData(studyData);
            await Database.Save();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<StudyDataDto> GetStudyDataByUserId(Guid userId)
    {
        try
        {
            var studyData = await Database.StudyData.GetStudyDataByUserId(userId);
            if (studyData == null)
                return null;
            return _mapper.Map<StudyDataDto>(studyData);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

