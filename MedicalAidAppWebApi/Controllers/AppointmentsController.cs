using AutoMapper;
using MedicalAidAppWebApi.AnonymousModels;
using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Dtos;
using MedicalAidAppWebApi.Models;
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

        [HttpGet("{email}", Name = nameof(GetAppointments))]
        public ActionResult<ICollection<AppointmentReadDto>> GetAppointments(string email)
        {
            ICollection<Appointment> appointments = _repository.GetAppointments(email);

            if (appointments == default)
                return NotFound();

            return Ok(_mapper.Map<ICollection<AppointmentReadDto>>(appointments));
        }

        [HttpPost]
        public ActionResult<AppointmentReadDto> CreateAppointment(AppointmentCreateDto appointmentCreateDto)
        {
            AppointmentAnonymous model = _mapper.Map<AppointmentAnonymous>(appointmentCreateDto);
            _repository.CreateAppointment(model);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetAppointments), new { email = model.PatientEmail }, _mapper.Map<AppointmentReadDto>(model));
        }
    }
}
