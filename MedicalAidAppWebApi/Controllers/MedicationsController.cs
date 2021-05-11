using AutoMapper;
using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Dtos;
using MedicalAidAppWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MedicalAidAppWebApi.Controllers
{
    [ApiController]
    [Route("medications")]
    public class MedicationsController : ControllerBase
    {
        private readonly IMedicationRepo _repository;
        private readonly IMapper _mapper;

        public MedicationsController(IMedicationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{email}", Name = nameof(GetMedications))]
        public ActionResult<ICollection<MedicationReadDto>> GetMedications(string email)
        {
            var medications = _repository.GetMedications(email);

            if (medications == default)
                return NotFound();

            return Ok(_mapper.Map<ICollection<MedicationReadDto>>(medications));
        }

        [HttpPost]
        public ActionResult<MedicationReadDto> CreateMedication(MedicationCreateDto medicationCreateDto)
        {
            var model = _mapper.Map<Medication>(medicationCreateDto);
            _repository.CreateMedication(model);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetMedications), new { email = medicationCreateDto.PatientEmail }, _mapper.Map<MedicationReadDto>(model));
        }
    }
}
