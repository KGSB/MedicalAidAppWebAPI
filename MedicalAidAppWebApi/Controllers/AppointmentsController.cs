using AutoMapper;
using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Controllers
{
    [ApiController]
    [Route("appointments")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepo _repository;
        private readonly IMapper _mapper;

        public AppointmentsController(IAppointmentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{email}")]
        public ActionResult<ICollection<AppointmentReadDto>> GetAppointments(string email)
        {
            var appointments = _repository.GetAppointments(email);

            if (appointments == default)
                return NotFound();

            return Ok(_mapper.Map<ICollection<AppointmentReadDto>>(appointments));
        }
    }
}
