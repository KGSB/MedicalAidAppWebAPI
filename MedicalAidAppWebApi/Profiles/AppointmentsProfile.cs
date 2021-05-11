using AutoMapper;
using MedicalAidAppWebApi.Dtos;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Profiles
{
    public class AppointmentsProfile : Profile
    {
        public AppointmentsProfile()
        {
            CreateMap<Appointment, AppointmentReadDto>();
            CreateMap<AppointmentCreateUpdateDto, Appointment>()
                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.PatientEmail));
            CreateMap<Appointment, AppointmentCreateUpdateDto>()
                .ForPath(dest => dest.PatientEmail, opt => opt.MapFrom(src => src.User.Email));
        }
    }
}
