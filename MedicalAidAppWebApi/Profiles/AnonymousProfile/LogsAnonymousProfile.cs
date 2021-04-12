using AutoMapper;
using MedicalAidAppWebApi.AnonymousModels;
using MedicalAidAppWebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Profiles.AnonymousProfile
{
    public class LogsAnonymousProfile : Profile
    {
        public LogsAnonymousProfile()
        {
            CreateMap<LogCreateDto, LogAnonymous>();
            CreateMap<LogAnonymous, LogReadDto>();
        }
    }
}
