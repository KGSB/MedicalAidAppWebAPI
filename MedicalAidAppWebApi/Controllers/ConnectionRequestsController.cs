using AutoMapper;
using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Dtos;
using MedicalAidAppWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpPost]
        public ActionResult<ConnectionRequestReadDto> CreateConnectionRequest(ConnectionRequestCreateDto connectionRequestCreateDto)
        {
            ConnectionRequest model = _mapper.Map<ConnectionRequest>(connectionRequestCreateDto);
            ConnectionRequest returnModel = _repository.CreateConnectionRequest(model);
            _repository.SaveChanges();

            string routeValue;

            if (returnModel.RequesterId == returnModel.CaretakerId)
            {
                routeValue = returnModel.Patient.Email;
            }
            else
            {
                routeValue = returnModel.Caretaker.Email;
            }

            return CreatedAtRoute(nameof(GetConnectionRequests), new { email = routeValue }, _mapper.Map<ConnectionRequestReadDto>(returnModel));
        }
    }
}
