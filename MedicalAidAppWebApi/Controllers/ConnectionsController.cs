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
    [Route("connections")]
    public class ConnectionsController : ControllerBase
    {
        private readonly IConnectionRepo _repository;
        private readonly IMapper _mapper;

        public ConnectionsController(IConnectionRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{email}")]
        public ActionResult<ICollection<ConnectionReadDto>> GetConnections(string email)
        {
            var connections = _repository.GetConnections(email);

            if(connections == default)
                return NotFound();


            return Ok(connections);
        }
    }
}
