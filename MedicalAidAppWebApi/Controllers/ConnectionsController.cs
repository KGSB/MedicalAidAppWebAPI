using AutoMapper;
using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Dtos;
using MedicalAidAppWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet("{email}", Name = nameof(GetConnections))]
        public ActionResult<ICollection<ConnectionReadDto>> GetConnections(string email)
        {
            ICollection<Connection> connections = _repository.GetConnections(email);

            if(connections == default)
                return NotFound();

            return Ok(_mapper.Map<ICollection<ConnectionReadDto>>(connections));
        }

        [HttpPost]
        public ActionResult<ConnectionReadDto> CreateConnection(ConnectionCreateDto connectionCreateDto)
        {
            Connection model = _mapper.Map<Connection>(connectionCreateDto);
            _repository.CreateConnection(model);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetConnections), new { email = connectionCreateDto.AccepterEmail }, _mapper.Map<ConnectionReadDto>(model));
        }
    }
}
