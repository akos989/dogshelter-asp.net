using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DogShelter.Auth;
using DogShelter.DAL;
using DogShelter.DTO;
using DogShelter.Model;
using DogShelter.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DogShelter.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DogShelterDbContext db;

        private readonly UserManager<User> userManager;

        private readonly RoleManager<Role> roleManager;

        private readonly JwtSettings jwtSettings;

        public UserRepository(
            DogShelterDbContext db,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.jwtSettings = jwtSettings.Value;
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

        public async Task<IdentityResult> CreateUser(CreateUserDto createUserDto)
        {
            var user = new User
            {
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                UserName = createUserDto.Email
            };
            var createUserResult = await userManager.CreateAsync(user, createUserDto.Password);

            return createUserResult;
        }

        public async Task<string> LoginUser(LoginUserDto loginUserDto)
        {
            var user = userManager.Users.SingleOrDefault(u => u.UserName == loginUserDto.Email);

            if (user is null)
            {
                return "";
            }

            var userSigninResult = await userManager.CheckPasswordAsync(user, loginUserDto.Password);

            if (userSigninResult)
            {
                var roles = await userManager.GetRolesAsync(user);
                return GenerateJwt(user, roles);
            }
            return "";
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
                db.SaveChanges();
                return user.ToDto();
            }
            return null;
        }

        public async Task<IdentityResult> CreateRole(string roleName)
        {
            var newRole = new Role
            {
                Name = roleName
            };

            return await roleManager.CreateAsync(newRole);
        }

        public async Task<IdentityResult> AddUserToRole(string userEmail, string roleName)
        {
            var user = userManager.Users.SingleOrDefault(u => u.UserName == userEmail);

            return await userManager.AddToRoleAsync(user, roleName);
        }

        private string GenerateJwt(User user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
