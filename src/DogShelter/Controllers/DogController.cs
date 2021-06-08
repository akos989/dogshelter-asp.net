using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogShelter.DTO;
using DogShelter.Model;
using DogShelter.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DogShelter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogController : Controller
    {
        private readonly IDogsRepository repository;

        public DogController(IDogsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DogDto>> GetDogs(
            [FromQuery] string breed = null,
            [FromQuery] int olderThan = -1,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            return Ok(repository.GetDogs(breed, olderThan, pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public ActionResult<DogDto> GetDog(long id)
        {
            var dog = repository.GetDog(id);
            if (dog != null)
            {
                return Ok(dog);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
        public ActionResult<DogDto> CreateDog([FromBody] CreateDogDto createDogDto)
        {
            var createdDog = repository.CreateDog(createDogDto);
            return Created(nameof(GetDog), createdDog);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
        public ActionResult DeleteDog(long id)
        {
            var successful = repository.DeleteDog(id);
            if (successful)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
        public ActionResult<DogDto> UpdateDog(long id, [FromBody] CreateDogDto createDogDto)
        {
            var dog = repository.UpdateDog(id, createDogDto);
            if (dog != null)
            {
                return Ok(dog);
            }
            return NotFound();
        }
    }
}
