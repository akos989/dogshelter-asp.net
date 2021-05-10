using System;
using System.Collections.Generic;
using DogShelter.DTO;
using DogShelter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DogShelter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            return Ok(userRepository.GetUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(long id)
        {
            var user = userRepository.GetUser(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            return Ok(userRepository.CreateUser(createUserDto));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDog(long id)
        {
            var successful = userRepository.DeleteUser(id);
            if (successful)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch("{id}")]
        public ActionResult<UserDto> UpdateUser(long id, [FromBody] CreateUserDto createUserDto)
        {
            var user = userRepository.UpdateUser(id, createUserDto);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
    }
}
