using System;
namespace DogShelter.DTO
{
    public record DogDto
    {
        public long Id { get; init; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }
    }
}
