using AutoMapper;
using MedicalAidAppWebApi.AnonymousModels;
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

        [HttpGet("{email}", Name = nameof(GetConnectionRequests))]
        public ActionResult<ICollection<ConnectionRequestReadDto>> GetConnectionRequests(string email)
        {
            return Ok(_mapper.Map<ICollection<ConnectionRequestReadDto>>(_repository.GetConnectionRequests(email)));
        }

        //TODO: check for a pre-existing connection before creating a connection request.
        [HttpPost]
        public ActionResult<ConnectionRequestReadDto> CreateConnectionRequest(ConnectionRequestCreateDto connectionRequestCreateDto)
        {
            var model = _mapper.Map<ConnectionRequestAnonymous>(connectionRequestCreateDto);
            _repository.CreateConnectionRequest(model);
            _repository.SaveChanges();

            string routeValue;

            if (model.RequesterEmail == model.CaretakerEmail)
            {
                routeValue = model.PatientEmail;
            }
            else
            {
                routeValue = model.CaretakerEmail;
            }

            //the DTO returned doesn't supply the names since the CreateDto only contains emails. fix this if you have time.
            return CreatedAtRoute(nameof(GetConnectionRequests), new { email = routeValue }, _mapper.Map<ConnectionRequestReadDto>(model));
        }
    }
}
