using AutoMapper;
using MedicalAidAppWebApi.Dtos;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Profiles
{
    public class ConnectionRequestsProfile : Profile
    {
        public ConnectionRequestsProfile()
        {
            CreateMap<ConnectionRequest, ConnectionRequestReadDto>();
            CreateMap<ConnectionRequestCreateDto, ConnectionRequest>()
                .ForPath(dest => dest.Caretaker.Email, opt => opt.MapFrom(src => src.CaretakerEmail))
                .ForPath(dest => dest.Patient.Email, opt => opt.MapFrom(src => src.PatientEmail))
                .ForPath(dest => dest.Requester.Email, opt => opt.MapFrom(src => src.RequesterEmail));
        }
    }
}