using AutoMapper;
using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Dtos;
using MedicalAidAppWebApi.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        public ActionResult<AppointmentReadDto> CreateAppointment(AppointmentCreateUpdateDto appointmentCreateDto)
        {
            Appointment model = _mapper.Map<Appointment>(appointmentCreateDto);
            _repository.CreateAppointment(model);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetAppointments), new { email = model.User.Email }, _mapper.Map<AppointmentReadDto>(model));
        }

        [HttpPatch("{email}/{appointmentId}")]
        public ActionResult PatchAppointment(uint appointmentId, string email, JsonPatchDocument<AppointmentCreateUpdateDto> patchDocument)
        {
            ICollection<Appointment> appointments = _repository.GetAppointments(email);
            Appointment existingAppointment = null;

            foreach (Appointment appointment in appointments)
            {
                if (appointment.Id == appointmentId)
                {
                    existingAppointment = appointment;
                    break;
                }
            }

            if (existingAppointment == null)
            {
                return NotFound();
            }

            AppointmentCreateUpdateDto appointmentToPatch = _mapper.Map<AppointmentCreateUpdateDto>(existingAppointment);
            patchDocument.ApplyTo(appointmentToPatch, ModelState);

            if (!TryValidateModel(appointmentToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(appointmentToPatch, existingAppointment);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{appointmentId}")]
        public ActionResult DeleteAppointment(uint appointmentId)
        {
            _repository.DeleteAppointment(appointmentId);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
