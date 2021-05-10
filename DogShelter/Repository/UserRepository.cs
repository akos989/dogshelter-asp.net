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
    public class UserRepository : IUserRepository
    {
        private readonly DogShelterDbContext db;

        public UserRepository(DogShelterDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return db.Users
                .Include(user => user.Dogs)
                .Include(user => user.Shelters).ThenInclude(shelter => shelter.Dogs)
                .Select(user => user.ToDto());
        }

        public UserDto GetUser(long id)
        {
            var user = db.Users
                .Where(u => u.Id == id)
                .Include(user => user.Dogs)
                .Include(user => user.Shelters).ThenInclude(shelter => shelter.Dogs)
                .SingleOrDefault();

            if (user == null)
                return null;
            return user.ToDto();
        }

        public UserDto CreateUser(CreateUserDto createUserDto)
        {
            var user = new User
            {
                Name = createUserDto.Name,
                Phonenumber = createUserDto.Phonenumber
            };
            db.Users.Add(user);
            db.SaveChanges();
            return user.ToDto();
        }

        public bool DeleteUser(long id)
        {
            var user = db.Users.Where(u => u.Id == id).SingleOrDefault();
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public UserDto UpdateUser(long id, CreateUserDto createUserDto)
        {
            var user = db.Users
                .Where(u => u.Id == id)
                .Include(user => user.Dogs)
                .Include(user => user.Shelters).ThenInclude(shelter => shelter.Dogs)
                .SingleOrDefault();

            if (user != null)
            {
                user.Name = createUserDto.Name != null ? createUserDto.Name : user.Name;
                user.Phonenumber = createUserDto.Phonenumber != null ? createUserDto.Phonenumber : user.Phonenumber;
                db.SaveChanges();
                return user.ToDto();
            }
            return null;
        }
    }
}
