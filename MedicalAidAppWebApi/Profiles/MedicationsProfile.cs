using AutoMapper;
using MedicalAidAppWebApi.Dtos;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Profiles
{
    public class MedicationsProfile : Profile
    {
        public MedicationsProfile()
        {
            CreateMap<Medication, MedicationReadDto>();
            CreateMap<MedicationCreateUpdateDto, Medication>()
                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.PatientEmail));
            CreateMap<Medication, MedicationCreateUpdateDto>()
                .ForPath(dest => dest.PatientEmail, opt => opt.MapFrom(src => src.User.Email));
        }
    }
}
