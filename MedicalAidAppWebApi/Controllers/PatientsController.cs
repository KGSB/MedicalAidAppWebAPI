using AutoMapper;
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
    [Route("patients")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepo _repository;
        private readonly IMapper _mapper;

        public PatientsController(IPatientRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{email}", Name = nameof(GetPatientInfo))]
        public ActionResult<PatientReadDto> GetPatientInfo(string email)
        {
            Patient patient = _repository.GetPatientInfo(email);

            if (patient == default)
                return NotFound();
            
            return Ok(_mapper.Map<PatientReadDto>(patient));
        }

        [HttpPost]
        public ActionResult<PatientReadDto> CreatePatient(PatientCreateDto patientCreateDto)
        {
            Patient model = _mapper.Map<Patient>(patientCreateDto);
            _repository.CreatePatient(model);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetPatientInfo), new { email = model.Email }, _mapper.Map<PatientReadDto>(model));
        }
    }
}
