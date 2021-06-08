using System.Collections.Generic;
using System.Threading.Tasks;
using DogShelter.DTO;
using Microsoft.AspNetCore.Identity;

namespace DogShelter.Repository

{
    public interface IUserRepository
    {
        IEnumerable<UserDto> GetUsers();

        UserDto GetUser(long id);

        Task<IdentityResult> CreateUser(CreateUserDto createUserDto);

        Task<string> LoginUser(LoginUserDto loginUserDto);

        bool DeleteUser(long id);

        UserDto UpdateUser(long id, CreateUserDto createUserDto);

        Task<IdentityResult> CreateRole(string role);

        Task<IdentityResult> AddUserToRole(string userEmail, string role);
    }
}
