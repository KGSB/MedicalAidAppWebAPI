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
    [Route("logs")]
    public class LogsController : ControllerBase
    {
        private readonly ILogRepo _repository;
        private readonly IMapper _mapper;

        public LogsController(ILogRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{email}", Name = nameof(GetLogs))]
        public ActionResult<ICollection<LogReadDto>> GetLogs(string email)
        {
            ICollection<Log> logs = _repository.GetLogs(email);

            if (logs == default)
                return NotFound();

            return Ok(_mapper.Map<ICollection<LogReadDto>>(logs));
        }

        [HttpPost]
        public ActionResult<LogReadDto> CreateLog(LogCreateUpdateDto logCreateDto)
        {
            Log model = _mapper.Map<Log>(logCreateDto);
            _repository.CreateLog(model);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetLogs), new { email = logCreateDto.PatientEmail }, _mapper.Map<LogReadDto>(model));
        }

        [HttpPatch("{email}/{logId}")]
        public ActionResult PatchLog(uint logId, string email, JsonPatchDocument<LogCreateUpdateDto> patchDocument)
        {
            ICollection<Log> logs = _repository.GetLogs(email);
            Log existingLog = null;

            foreach (Log log in logs)
            {
                if (log.Id == logId)
                {
                    existingLog = log;
                    break;
                }
            }

            if (existingLog == null)
            {
                NotFound();
            }

            LogCreateUpdateDto logToPatch = _mapper.Map<LogCreateUpdateDto>(existingLog);
            patchDocument.ApplyTo(logToPatch, ModelState);

            if (!TryValidateModel(logToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(logToPatch, existingLog);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{logId}")]
        public ActionResult DeleteLog(uint logId)
        {
            _repository.DeleteLog(logId);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
