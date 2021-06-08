using System.Threading.Tasks;
using DogShelter.Controllers;
using DogShelter.DTO;
using DogShelter.Model;
using DogShelter.Repository;
using DogShelter.Utils;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DogShelter.Test.Controllers
{
    public class UserControllerTest
    {
        private UserController controller;
        private readonly Mock<IUserRepository> repositoryStub = new Mock<IUserRepository>();

        [Fact]
        public void GetUsers_ReturnsExisting()
        {
            // Arrange
            var expected = new[]
            {
                CreateRandomUser().ToDto(),
                CreateRandomUser().ToDto(),
                CreateRandomUser().ToDto()
            };

            repositoryStub
                .Setup(repo => repo.GetUsers())
                .Returns(expected);

            controller = new UserController(repositoryStub.Object);

            // Act
            var actionResult = controller.GetUsers();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().BeEquivalentTo(
                expected,
                options => options.ComparingByMembers<UserDto>()
            );
        }

        [Fact]
        public void GetUser_ReturnsExisting()
        {
            // Arrange
            var expected = CreateRandomUser().ToDto();
            repositoryStub.Setup(repo => repo.GetUser(It.IsAny<long>()))
                .Returns(expected);

            controller = new UserController(repositoryStub.Object);

            // Act
            var actionResult = controller.GetUser(1L);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().BeEquivalentTo(
                expected,
                options => options.ComparingByMembers<UserDto>()
            );
        }

        [Fact]
        public async Task CreateUser_ReturnsOK()
        {
            // Arrange
            var expected = CreateRandomUser().ToDto();
            
            repositoryStub.Setup(repo => repo.CreateUser(It.IsAny<CreateUserDto>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            controller = new UserController(repositoryStub.Object);

            // Act
            var actionResult = await controller.CreateUser(new CreateUserDto());

            // Assert
            Assert.IsType<OkResult>(actionResult);
        }


        [Fact]
        public async Task LoginUser_ReturnOK()
        {
            // Arrange
            var expected = "token";
            repositoryStub.Setup(repo => repo.LoginUser(It.IsAny<LoginUserDto>()))
                .Returns(Task.FromResult(expected));

            controller = new UserController(repositoryStub.Object);

            // Act
            var actionResult = await controller.LoginUser(new LoginUserDto());

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.Equal(result.Value, expected);
        }

        [Fact]
        public void DeleteUser_ReturnOK()
        {
            // Arrange
            repositoryStub.Setup(repo => repo.DeleteUser(It.IsAny<long>()))
                .Returns(true);

            controller = new UserController(repositoryStub.Object);

            // Act
            var actionResult = controller.DeleteUser(1L);

            // Assert
            Assert.IsType<OkResult>(actionResult);
        }

        private User CreateRandomUser()
        {
            return new User()
            {
                Id = 1L,
                Name = "TestUser"
            };
        }
    }
}
