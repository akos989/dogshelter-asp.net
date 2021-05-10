using System;
namespace DogShelter.DTO
{
    public class CreateDogDto
    {
        public string Name { get; set; }

        public int Age { get; set; } = -1;

        public string Breed { get; set; }
    }
}
