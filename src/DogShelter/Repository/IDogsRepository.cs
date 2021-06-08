using System;
using System.Collections.Generic;
using System.Linq;
using DogShelter.DTO;

namespace DogShelter.Repository
{
    public interface IDogsRepository
    {
        List<DogDto> GetDogs(string breed, int olderThan, int pageNumber, int pageSize);

        DogDto GetDog(long id);

        DogDto CreateDog(CreateDogDto createDogDto);

        bool DeleteDog(long id);

        DogDto UpdateDog(long id, CreateDogDto createDogDto);
    }
}
