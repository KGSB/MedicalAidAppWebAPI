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
            var logs = _repository.GetLogs(email);

            if (logs == default)
                return NotFound();

            return Ok(_mapper.Map<ICollection<LogReadDto>>(logs));
        }

        [HttpPost]
        public ActionResult<LogReadDto> CreateLog(LogCreateDto logCreateDto)
        {
            var model = _mapper.Map<LogAnonymous>(logCreateDto);
            _repository.CreateLog(model);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetLogs), new { email = logCreateDto.PatientEmail }, _mapper.Map<LogReadDto>(model));
        }
    }
}
