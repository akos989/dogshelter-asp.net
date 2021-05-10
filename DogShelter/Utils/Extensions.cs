using System.Linq;
using DogShelter.DTO;
using DogShelter.Model;

namespace DogShelter.Utils
{
    public static class Extensions
    {
        public static DogDto ToDto(this Dog dog)
        {
            return new DogDto
            {
                Id = dog.Id,
                Name = dog.Name,
                Age = dog.Age,
                Breed = dog.Breed
            };
        }

        public static ShelterDto ToDto(this Shelter shelter)
        {
            return new ShelterDto
            {
                Id = shelter.Id,
                Name = shelter.Name,
                Address = shelter.Address,
                Dogs = shelter.Dogs.Select(dog => dog.ToDto()).ToList()
            };
        }

        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Phonenumber = user.Phonenumber,
                Dogs = user.Dogs.Select(dog => dog.ToDto()).ToList(),
                Shelters = user.Shelters.Select(shelter => shelter.ToDto()).ToList()
            };
        }
    }
}
