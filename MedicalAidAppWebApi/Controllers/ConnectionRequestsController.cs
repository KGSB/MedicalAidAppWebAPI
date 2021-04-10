using AutoMapper;
using MedicalAidAppWebApi.Data.Interfaces;
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
        public ActionResult<ICollection<Tuple<string, string>>> GetConnectionRequests(string email)
        {
            return Ok(_repository.GetConnectionRequests(email));
        }
    }
}
