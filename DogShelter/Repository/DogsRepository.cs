using System.Collections.Generic;
using System.Linq;
using DogShelter.DAL;
using DogShelter.DTO;
using DogShelter.Model;
using DogShelter.Utils;

namespace DogShelter.Repository
{
    public class DogsRepository : IDogsRepository
    {
        private readonly DogShelterDbContext db;

        public DogsRepository(DogShelterDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<DogDto> GetDogs(string breed, int olderThan)
        {
            return db.Dogs
                .Where(dog => dog.Age > olderThan)
                .Where(dog => breed == null || breed == dog.Breed)
                .Select(dog => dog.ToDto());
        }

        public DogDto GetDog(long id)
        {
            var dog = db.Dogs.Where(d => d.Id == id).SingleOrDefault();
            if (dog == null)
                return null;
            return dog.ToDto();
        }

        public DogDto CreateDog(CreateDogDto createDogDto)
        {
            var dog = new Dog
            {
                Age = createDogDto.Age,
                Name = createDogDto.Name,
                Breed = createDogDto.Breed
            };
            db.Dogs.Add(dog);
            db.SaveChanges();
            return dog.ToDto();
        }

        public bool DeleteDog(long id)
        {
            var dog = db.Dogs.Where(d => d.Id == id).SingleOrDefault();
            if (dog != null)
            {
                db.Dogs.Remove(dog);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public DogDto UpdateDog(long id, CreateDogDto createDogDto)
        {
            var dog = db.Dogs.Where(d => d.Id == id).SingleOrDefault();
            if (dog != null)
            {
                dog.Name = createDogDto.Name != null ? createDogDto.Name : dog.Name;
                dog.Age = createDogDto.Age != -1 ? createDogDto.Age : dog.Age;
                dog.Breed = createDogDto.Breed != null ? createDogDto.Breed : dog.Breed;
                db.SaveChanges();
                return dog.ToDto();
            }
            return null;
        }
    }
}
