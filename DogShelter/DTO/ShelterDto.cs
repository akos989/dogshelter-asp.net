using System.Collections.Generic;

namespace DogShelter.DTO
{
    public class ShelterDto
    {
        public long Id { get; init; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<DogDto> Dogs { get; set; }
    }
}
