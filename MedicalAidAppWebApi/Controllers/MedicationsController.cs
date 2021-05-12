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
        public ActionResult<MedicationReadDto> CreateMedication(MedicationCreateUpdateDto medicationCreateDto)
        {
            var model = _mapper.Map<Medication>(medicationCreateDto);
            _repository.CreateMedication(model);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetMedications), new { email = medicationCreateDto.PatientEmail }, _mapper.Map<MedicationReadDto>(model));
        }

        [HttpPatch("{email}/{medicationId}")]
        public ActionResult PatchMedication(uint medicationId, string email, JsonPatchDocument<MedicationCreateUpdateDto> patchDocument)
        {
            ICollection<Medication> medications = _repository.GetMedications(email);
            Medication existingMedication = null;

            foreach (Medication medication in medications)
            {
                if (medication.Id == medicationId)
                {
                    existingMedication = medication;
                    break;
                }
            }

            if (existingMedication == null)
            {
                return NotFound();
            }

            MedicationCreateUpdateDto medicationToPatch = _mapper.Map<MedicationCreateUpdateDto>(existingMedication);
            patchDocument.ApplyTo(medicationToPatch, ModelState);

            if (!TryValidateModel(medicationToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(medicationToPatch, existingMedication);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{medicationId}")]
        public ActionResult DeleteMedication(uint medicationId)
        {
            _repository.DeleteMedication(medicationId);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
