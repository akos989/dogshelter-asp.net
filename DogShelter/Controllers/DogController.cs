using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogShelter.DTO;
using DogShelter.Model;
using DogShelter.Repository;
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
        public ActionResult<IEnumerable<DogDto>> GetDogs([FromQuery] string breed, [FromQuery] int olderThan = 0)
        {
            return Ok(repository.GetDogs(breed, olderThan));
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
        public ActionResult<DogDto> CreateDog([FromBody] CreateDogDto createDogDto)
        {
            return Ok(repository.CreateDog(createDogDto));
        }

        [HttpDelete("{id}")]
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
