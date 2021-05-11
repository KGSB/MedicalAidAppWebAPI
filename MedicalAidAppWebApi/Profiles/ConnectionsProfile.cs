using AutoMapper;
using MedicalAidAppWebApi.Dtos;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Profiles
{
    public class ConnectionsProfile : Profile
    {
        public ConnectionsProfile()
        {
            CreateMap<Connection, ConnectionReadDto>();
            CreateMap<ConnectionCreateDto, Connection>()
                .ForPath(dest => dest.Caretaker.Email, opt => opt.MapFrom(src => src.CaretakerEmail))
                .ForPath(dest => dest.Patient.Email, opt => opt.MapFrom(src => src.PatientEmail));
        }
    }
}