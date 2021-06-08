using System;
using System.Collections.Generic;
using DogShelter.DTO;

namespace DogShelter.Repository
{
    public interface IShelterRepository
    {
        IEnumerable<ShelterDto> GetShelters();

        ShelterDto GetShelter(long id);

        ShelterDto CreateShelter(CreateShelterDto createShelterDto);

        bool DeleteShelter(long id);

        ShelterDto UpdateShelter(long id, CreateShelterDto createShelterDto);

        ShelterDto AddDog(long shelterId, long dogId);

        ShelterDto RemoveDog(long shelterId, long dogId);
    }
}
