using AIScheduleUI5.BLL.DTOs;
using AIScheduleUI5.BLL.Interfaces;
using AIScheduleUI5.DAL.Entities;
using AIScheduleUI5.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace AIScheduleUI5.BLL.Services;

public  class UniversityService : IUniversityService
{
    IUnitOfWork Database { get; set; }
    IMapper _mapper;

    public UniversityService(IUnitOfWork database, IMapper mapper)
    {
        Database = database;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UniversityDto>> GetAllAsync()
    {
        var universities = await Database.Universities.GetAll();
        return _mapper.Map<IQueryable<University>, IEnumerable<UniversityDto>>(universities);

    }


}

