using AutoMapper;
using MedicalAidAppWebApi.Dtos;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Profiles
{
    public class LogsProfile : Profile
    {
        public LogsProfile()
        {
            CreateMap<Log, LogReadDto>();
            CreateMap<LogCreateUpdateDto, Log>()
                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.PatientEmail));
            CreateMap<Log, LogCreateUpdateDto>()
                .ForPath(dest => dest.PatientEmail, opt => opt.MapFrom(src => src.User.Email));
        }
    }
}
