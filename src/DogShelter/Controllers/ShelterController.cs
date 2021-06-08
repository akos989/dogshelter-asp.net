using System.Collections.Generic;
using DogShelter.DTO;
using DogShelter.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogShelter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShelterController : Controller
    {
        private readonly IShelterRepository repository;

        public ShelterController(IShelterRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShelterDto>> GetShelters()
        {
            return Ok(repository.GetShelters());
        }

        [HttpGet("{id}")]
        public ActionResult<ShelterDto> GetShelter(long id)
        {
            var shelter = repository.GetShelter(id);
            if (shelter != null)
            {
                return Ok(shelter);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
        public ActionResult<ShelterDto> CreateShelter([FromBody] CreateShelterDto createShelterDto)
        {
            return Ok(repository.CreateShelter(createShelterDto));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteShelter(long id)
        {
            var successful = repository.DeleteShelter(id);
            if (successful)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
        public ActionResult<DogDto> UpdateShelter(long id, [FromBody] CreateShelterDto createShelterDto)
        {
            var shelter = repository.UpdateShelter(id, createShelterDto);
            if (shelter != null)
            {
                return Ok(shelter);
            }
            return NotFound();
        }

        [HttpPatch("{shelterId}/add-dog/{dogId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
        public ActionResult<DogDto> AddDog(long shelterId, long dogId)
        {
            var shelter = repository.AddDog(shelterId, dogId);
            if (shelter != null)
            {
                return Ok(shelter);
            }
            return NotFound();
        }

        [HttpPatch("{shelterId}/remove-dog/{dogId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
        public ActionResult<DogDto> RemoveDog(long shelterId, long dogId)
        {
            var shelter = repository.RemoveDog(shelterId, dogId);
            if (shelter != null)
            {
                return Ok(shelter);
            }
            return NotFound();
        }
    }
}
