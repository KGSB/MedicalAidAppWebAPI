using AutoMapper;
using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Dtos;
using MedicalAidAppWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            Appointment model = _mapper.Map<Appointment>(appointmentCreateDto);
            _repository.CreateAppointment(model);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetAppointments), new { email = model.User.Email }, _mapper.Map<AppointmentReadDto>(model));
        }
    }
}
