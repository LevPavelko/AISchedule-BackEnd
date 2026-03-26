using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIScheduleUI5.BLL.DTOs;
using AIScheduleUI5.DAL.Entities;
using AutoMapper;


namespace AIScheduleUI5.BLL.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();


            CreateMap<Major, MajorDto>();


            CreateMap<Schedule, ScheduleDto>();

            CreateMap<StudyData, StudyDataDto>()
                .ForMember(dest => dest.Major, opt => opt.MapFrom(src => src.Major))
                .ForMember(dest => dest.University, opt => opt.MapFrom(src => src.University));


            CreateMap<University, UniversityDto>();

        }
    }
}
