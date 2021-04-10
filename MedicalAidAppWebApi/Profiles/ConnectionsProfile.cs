using AutoMapper;
using MedicalAidAppWebApi.Models;
using MedicalAidAppWebApi.Dtos;
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
        }
    }
}
