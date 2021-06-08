namespace DogShelter.Model
{
    public record Dog
    {
        public long Id { get; init; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        public long? ShelterId { get; set; }

        public Shelter Shelter { get; set; }

        public long? OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
