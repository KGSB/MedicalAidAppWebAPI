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
        }
    }
}
