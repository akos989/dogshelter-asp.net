using System;
using System.Collections.Generic;
using System.Linq;
using DogShelter.DAL;
using DogShelter.DTO;
using DogShelter.Model;
using DogShelter.Utils;
using Microsoft.EntityFrameworkCore;

namespace DogShelter.Repository
{
    public class ShelterRepository : IShelterRepository
    {

        private readonly DogShelterDbContext db;

        public ShelterRepository(DogShelterDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ShelterDto> GetShelters()
        {
            return db.Shelters
                .Include(shelter => shelter.Dogs)
                .Select(shelter => shelter.ToDto())
                .ToList();
        }
        
        public ShelterDto GetShelter(long id)
        {
            var shelter = db.Shelters
                .Where(s => s.Id == id)
                .Include(s => s.Dogs)
                .SingleOrDefault();

            if (shelter == null)
                return null;
            return shelter.ToDto();
        }

        public ShelterDto CreateShelter(CreateShelterDto createShelterDto)
        {
            var shelter = new Shelter
            {
                Name = createShelterDto.Name,
                Address = createShelterDto.Address
            };
            db.Shelters.Add(shelter);
            db.SaveChanges();
            return shelter.ToDto();
        }

        public bool DeleteShelter(long id)
        {
            var shelter = db.Shelters.Where(s => s.Id == id).SingleOrDefault();
            if (shelter != null)
            {
                db.Shelters.Remove(shelter);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public ShelterDto UpdateShelter(long id, CreateShelterDto createShelterDto)
        {
            var shelter = db.Shelters
                .Where(s => s.Id == id)
                .Include(shelter => shelter.Dogs)
                .SingleOrDefault();

            if (shelter != null)
            {
                shelter.Name = createShelterDto.Name != null ? createShelterDto.Name : shelter.Name;
                shelter.Address = createShelterDto.Address != null ? createShelterDto.Address : shelter.Address;
                db.SaveChanges();
                return shelter.ToDto();
            }
            return null;
        }

        public ShelterDto AddDog(long shelterId, long dogId)
        {
            var shelter = db.Shelters
                .Where(s => s.Id == shelterId)
                .Include(shelter => shelter.Dogs)
                .SingleOrDefault();
            var dog = db.Dogs.Where(d => d.Id == dogId).SingleOrDefault();

            if (dog == null || shelter == null)
            {
                return null;
            }
            shelter.Dogs.Add(dog);
            db.SaveChanges();
            return shelter.ToDto();
        }

        public ShelterDto RemoveDog(long shelterId, long dogId)
        {
            var shelter = db.Shelters
                .Where(s => s.Id == shelterId)
                .Include(shelter => shelter.Dogs)
                .SingleOrDefault();
            var dog = db.Dogs.Where(d => d.Id == dogId).SingleOrDefault();

            if (dog == null || shelter == null)
            {
                return null;
            }
            shelter.Dogs.Remove(dog);
            db.SaveChanges();
            return shelter.ToDto();
        }
    }
}
