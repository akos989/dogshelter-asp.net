using System.Collections.Generic;
using DogShelter.Controllers;
using DogShelter.DTO;
using DogShelter.Model;
using DogShelter.Repository;
using DogShelter.Utils;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DogShelter.Test.Controllers
{
    public class DogControllerTest
    {
        private DogController controller;
        private readonly Mock<IDogsRepository> repositoryStub = new Mock<IDogsRepository>();

        [Fact]
        public void GetDogs_ReturnsExisting()
        {
            // Arrange
            var expected = new List<DogDto>(
                new[]
                {
                    CreateRandomDog().ToDto(),
                    CreateRandomDog().ToDto(),
                    CreateRandomDog().ToDto()
                }
            );
                
            repositoryStub
                .Setup(repo => repo.GetDogs(
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()
                ))
                .Returns(expected);

            controller = new DogController(repositoryStub.Object);

            // Act
            var actionResult = controller.GetDogs();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().BeEquivalentTo(
                expected,
                options => options.ComparingByMembers<DogDto>()
            );
        }

        [Fact]
        public void GetDog_ReturnsExisting()
        {
            // Arrange
            var expected = CreateRandomDog().ToDto();
            repositoryStub.Setup(repo => repo.GetDog(It.IsAny<long>()))
                .Returns(expected);

            controller = new DogController(repositoryStub.Object);

            // Act
            var actionResult = controller.GetDog(1L);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Value.Should().BeEquivalentTo(
                expected,
                options => options.ComparingByMembers<DogDto>()
            );
        }

        [Fact]
        public void GetDog_ReturnsNotFound()
        {
            // Arrange
            repositoryStub.Setup(repo => repo.GetDog(It.IsAny<long>()))
                .Returns((DogDto) null);

            controller = new DogController(repositoryStub.Object);

            // Act
            var actionResult = controller.GetDog(1L);

            // Assert
            actionResult.Result.Should().BeOfType<NotFoundResult>();
        }
        
        [Fact]
        public void CreateDog_ReturnsCreated()
        {
            // Arrange
            var expected = CreateRandomDog().ToDto();

            repositoryStub.Setup(repo => repo.CreateDog(It.IsAny<CreateDogDto>()))
                .Returns(expected);

            controller = new DogController(repositoryStub.Object);

            // Act
            var actionResult = controller.CreateDog(new CreateDogDto());

            // Assert
            var result = actionResult.Result as CreatedResult;
            result.Value.Should().BeEquivalentTo(
                expected,
                options => options.ComparingByMembers<DogDto>()
            );
        }

        [Fact]
        public void DeleteDog_ReturnsOk()
        {
            // Arrange
            repositoryStub.Setup(repo => repo.DeleteDog(It.IsAny<long>()))
                .Returns(true);

            controller = new DogController(repositoryStub.Object);

            // Act
            var actionResult = controller.DeleteDog(1L);

            // Assert
            Assert.IsType<OkResult>(actionResult);
        }

        [Fact]
        public void UpdateDog_ReturnsNotFound()
        {
            // Arrange
            repositoryStub
                .Setup(repo => repo.UpdateDog(
                    It.IsAny<long>(),
                    It.IsAny<CreateDogDto>()
                    ))
                .Returns((DogDto) null);

            controller = new DogController(repositoryStub.Object);

            // Act
            var actionResult = controller.UpdateDog(1L, new CreateDogDto());

            // Assert
            var result = actionResult.Result;
            Assert.IsType<NotFoundResult>(result);
        }

        private Dog CreateRandomDog()
        {
            return new Dog()
            {
                Id = 1L,
                Name = "TestDog",
                Age = 5,
                Breed = "TestBreed"
            };
        }
    }
}
