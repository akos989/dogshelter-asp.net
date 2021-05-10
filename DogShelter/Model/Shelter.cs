using System;
using System.Collections.Generic;

namespace DogShelter.Model
{
    public record Shelter
    {
        public long Id { get; init; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<Dog> Dogs { get; set; } = new List<Dog>();

        public long OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
