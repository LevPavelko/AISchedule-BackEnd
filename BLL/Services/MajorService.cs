using AIScheduleUI5.BLL.DTOs;
using AIScheduleUI5.BLL.Interfaces;
using AIScheduleUI5.DAL.Entities;
using AIScheduleUI5.DAL.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AIScheduleUI5.BLL.Services;

public sealed class MajorService : IMajorService
{
    IUnitOfWork Database { get; set; }
    IMapper _mapper;

    public MajorService (IUnitOfWork uow, IMapper mapper)
    {
        Database = uow;
        _mapper = mapper;
    }
    public async Task<List<MajorDto>> GetByUniversityIdAsync(Guid uniId)
    {
        if(uniId == null)
            throw new ArgumentNullException(nameof(uniId));
        var majorsQuery = await Database.Majors.GetAll();
        var majorsSorted = majorsQuery.Where(m=> m.UniId == uniId).ToList();

        return _mapper.Map<List<Major>, List<MajorDto>>(majorsSorted);

    }

}

