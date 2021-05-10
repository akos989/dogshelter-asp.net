using System;
using System.Collections.Generic;
using DogShelter.DTO;
using DogShelter.Model;
namespace DogShelter.Repository

{
    public interface IUserRepository
    {
        IEnumerable<UserDto> GetUsers();

        UserDto GetUser(long id);

        UserDto CreateUser(CreateUserDto createUserDto);

        bool DeleteUser(long id);

        UserDto UpdateUser(long id, CreateUserDto createUserDto);
    }
}
