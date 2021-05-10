using System;
using System.Collections.Generic;

namespace DogShelter.DTO
{
    public class UserDto
    {
        public long Id { get; init; }

        public string Name { get; set; }

        public string Phonenumber { get; set; }

        public List<DogDto> Dogs { get; set; }

        public List<ShelterDto> Shelters { get; set; }
    }
}
