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

        [HttpGet("{email}")]
        public ActionResult<ICollection<LogReadDto>> GetLogs(string email)
        {
            var logs = _repository.GetLogs(email);

            if (logs == default)
                return NotFound();

            return Ok(_mapper.Map<ICollection<LogReadDto>>(logs));
        }
    }
}
