using System;
using System.Collections.Generic;
using DogShelter.DTO;
using DogShelter.Model;

namespace DogShelter.Repository
{
    public interface IDogsRepository
    {
        IEnumerable<DogDto> GetDogs(string breed, int olderThan);

        DogDto GetDog(long id);

        DogDto CreateDog(CreateDogDto createDogDto);

        bool DeleteDog(long id);

        DogDto UpdateDog(long id, CreateDogDto createDogDto);
    }
}
