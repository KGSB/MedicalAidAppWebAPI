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
    [Route("caretakers")]
    public class CaretakersController : ControllerBase
    {
        private readonly ICaretakerRepo _repository;
        private readonly IMapper _mapper;

        public CaretakersController(ICaretakerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{email}")]
        public ActionResult<CaretakerReadDto> GetCaretakerInfo(string email)
        {
            var caretaker = _repository.GetCaretakerInfo(email);

            if (caretaker == default)
                return NotFound();

            return Ok(_mapper.Map<CaretakerReadDto>(caretaker));
        }
    }
}
