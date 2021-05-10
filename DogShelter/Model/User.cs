using System;
using System.Collections.Generic;

namespace DogShelter.Model
{
    public class User
    {
        public long Id { get; init; }

        public string Name { get; set; }

        public string Phonenumber { get; set; }

        public ICollection<Dog> Dogs { get; set; } = new List<Dog>();

        public ICollection<Shelter> Shelters { get; set; } = new List<Shelter>();
    }
}
