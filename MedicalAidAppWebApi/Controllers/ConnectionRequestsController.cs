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
    [Route("connectionRequests")]
    public class ConnectionRequestsController : ControllerBase
    {
        private readonly IConnectionRequestRepo _repository;
        private readonly IMapper _mapper;

        public ConnectionRequestsController(IConnectionRequestRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{email}")]
        public ActionResult<ICollection<ConnectionRequestReadDto>> GetConnectionRequests(string email)
        {
            return Ok(_repository.GetConnectionRequests(email));
        }
    }
}
