using AutoMapper;
using MedicalAidAppWebApi.AnonymousModels;
using MedicalAidAppWebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Profiles.AnonymousProfile
{
    public class AppointmentsAnonymousProfile : Profile
    {
        public AppointmentsAnonymousProfile()
        {
            CreateMap<AppointmentCreateDto, AppointmentAnonymous>();
            CreateMap<AppointmentAnonymous, AppointmentReadDto>();
        }
    }
}
