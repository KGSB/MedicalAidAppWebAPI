using AutoMapper;
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
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet("email", Name = nameof(GetUserInfo))]
        public ActionResult<UserReadDto> GetUserInfo(string email)
        {
            User user = _repository.GetUserInfo(email);

            if (user == null)
                return NotFound();
            else
                return Ok(_mapper.Map<UserReadDto>(user));
        }

        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {
            User model = _mapper.Map<User>(userCreateDto);
            _repository.CreateUser(model);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetUserInfo), new { email = model.Email }, _mapper.Map<UserReadDto>(model));
        }
    }
}
