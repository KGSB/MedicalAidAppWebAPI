using AutoMapper;
using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Dtos;
using MedicalAidAppWebApi.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        public ActionResult<UserReadDto> CreateUser(UserCreateUpdateDto userCreateDto)
        {
            User model = _mapper.Map<User>(userCreateDto);
            _repository.CreateUser(model);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetUserInfo), new { email = model.Email }, _mapper.Map<UserReadDto>(model));
        }

        //[HttpPut]
        //public ActionResult UpdateUser(UserCreateDto userUpdateDto)
        //{
        //    User existingUser = _repository.GetUserInfo(userUpdateDto.Email);
        //    _mapper.Map(userUpdateDto, existingUser);
        //    _repository.SaveChanges();
        //    return NoContent();
        //}

        [HttpPatch("email")]
        public ActionResult PartialUpdateUser(string email, JsonPatchDocument<UserCreateUpdateDto> patchDocument)
        {
            User existingUser = _repository.GetUserInfo(email);
            UserCreateUpdateDto userToPatch = _mapper.Map<UserCreateUpdateDto>(existingUser);
            patchDocument.ApplyTo(userToPatch, ModelState);

            if (!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userToPatch, existingUser);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("email")]
        public ActionResult DeleteUser(string email)
        {
            _repository.DeleteUser(email);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}