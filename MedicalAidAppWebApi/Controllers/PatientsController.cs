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

        [HttpGet("{email}")]
        public ActionResult<PatientReadDto> GetPatientInfo(string email)
        {
            var patient = _repository.GetPatientInfo(email);

            if (patient == default)
                return NotFound();
            
            return Ok(_mapper.Map<PatientReadDto>(patient));
        }
    }
}
