using Microsoft.AspNetCore.Mvc;
using Moq;
using RestFulAPI.Application.DTOs;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Controllers;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;


namespace RentProjectTests
{
    public class LandlordControllerTests
    {
        private readonly Mock<ILandlordService> _mockService;
        private readonly Mock<ILandlord> _mockRepo;
        private readonly LandLordController landlordController;

        public LandlordControllerTests()
        {
            _mockService = new Mock<ILandlordService>();
            landlordController = new LandLordController(_mockService.Object);
            _mockRepo = new Mock<ILandlord>();
        }

        [Fact]
        public async Task Get_ReturnsListOfLandlords()
        {
            // Arrange
            var landlords = new List<Landlord>
            {
                new Landlord { Id = 1, Login = "landlord1", Email = "landlord1@example.com" },
                new Landlord { Id = 2, Login = "landlord2", Email = "landlord2@example.com" }
            };
            _mockService.Setup(service => service.GetFullByPageAsync(1, 20)).ReturnsAsync(landlords);

            // Act
            var result = await landlordController.Get();

            // Assert
            var actionResult = Assert.IsType<List<Landlord>>(result);
            Assert.NotEmpty(actionResult);
        }

        [Fact]
        public async Task GetSingle_ReturnsLandlord_WhenExists()
        {
            // Arrange
            int id = 1;
            var landlord = new Landlord { Id = id, Login = "landlord1", Email = "landlord1@example.com" };
            _mockService.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(landlord);

            // Act
            var result = await landlordController.GetSingle(id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Landlord>>(result);
            var returnValue = Assert.IsType<Landlord>(actionResult.Value);
            Assert.Equal(id, returnValue.Id);
        }

        [Fact]
        public async Task GetSingle_ReturnsNotFound_WhenLandlordDoesNotExist()
        {
            // Arrange
            int id = 1;
            _mockService.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((Landlord)null);

            // Act
            var result = await landlordController.GetSingle(id);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Put_ReturnsBadRequest_WhenLandlordIsNull()
        {
            // Act
            var result = await landlordController.Put(null);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task Put_ReturnsOk_WhenLandlordIsValid()
        {
            // Arrange
            var landlord = new Landlord { Id = 1, Login = "landlord1", Email = "landlord1@example.com" };
            _mockService.Setup(service => service.AddAsync(landlord)).ReturnsAsync(1);

            // Act
            var result = await landlordController.Put(landlord);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Landlord>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }


    }
}
