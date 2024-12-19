using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Application.Services;
using RestFulAPI.Controllers;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;
using Xunit.Sdk;

namespace RentProjectTests
{
    public class LandlordAdditionalInfoControllerTests
    {

        private readonly Mock<ILandlordAdditionalInfoService> _mockService;
        private readonly Mock<ILandlordAdditionalInfo> _mockRepo;
        private readonly LandLordAdditionalInfoController landlordAdditionalInfoController;

        public LandlordAdditionalInfoControllerTests()
        {
            _mockService = new Mock<ILandlordAdditionalInfoService>();
            landlordAdditionalInfoController = new LandLordAdditionalInfoController(_mockService.Object);
            _mockRepo = new Mock<ILandlordAdditionalInfo>();
        }

        [Fact]
        public async Task Get_ReturnsListOfLandlordAdditionalInfo()
        {
            // Arrange
            int pageNumber = 1;
            int pageSize = 20;
            var landlords = new List<LandlordAdditionalInfo>
            {
                new LandlordAdditionalInfo { Id = 1, Name = "John", Surname = "Doe", AverageMark = 4.5m },
                new LandlordAdditionalInfo { Id = 2, Name = "Jane", Surname = "Smith", AverageMark = 4.7m }
            };

            _mockService.Setup(service => service.GetFullByPageAsync(pageNumber, pageSize)).ReturnsAsync(landlords);

            // Act
            var result = await landlordAdditionalInfoController.Get(pageNumber, pageSize);

            // Assert
            var actionResult = Assert.IsType<List<LandlordAdditionalInfo>>(result);
            Assert.NotEmpty(actionResult); // Ensure the list is not empty
        }

        [Fact]
        public async Task GetSingle_ReturnsNotFound_WhenInfoDoesNotExist()
        {
            // Arrange
            int id = 1;
            _mockService.Setup(service => service.GetAdditionalInfoByIdAsync(id)).ReturnsAsync((LandlordAdditionalInfo)null);

            // Act
            var result = await landlordAdditionalInfoController.GetSingle(id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<LandlordAdditionalInfo>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result); // Expect NotFound
        }

        [Fact]
        public async Task GetSingle_ReturnsLandlordAdditionalInfo_WhenInfoExists()
        {
            // Arrange
            int id = 1;
            var landlordInfo = new LandlordAdditionalInfo { Id = id, Name = "John", Surname = "Doe" };
            _mockService.Setup(service => service.GetAdditionalInfoByIdAsync(id)).ReturnsAsync(landlordInfo);

            // Act
            var result = await landlordAdditionalInfoController.GetSingle(id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<LandlordAdditionalInfo>>(result);
            var returnValue = Assert.IsType<LandlordAdditionalInfo>(actionResult.Value);
            Assert.Equal(id, returnValue.Id); // Assert the correct data is returned
        }

        [Fact]
        public async Task Put_ReturnsBadRequest_WhenInfoIsNull()
        {
            // Act
            var result = await landlordAdditionalInfoController.Put(null);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result); // Expect BadRequest
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenInfoDoesNotExist()
        {
            // Arrange
            int id = 1;
            _mockService.Setup(service => service.DeleteAdditionalInfoAsync(id)).ReturnsAsync(0); // Simulate failure

            // Act
            var result = await landlordAdditionalInfoController.Delete(id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<LandlordAdditionalInfo>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result); // Expect NotFound
        }

        [Fact]
        public async Task Delete_ReturnsOk_WhenInfoIsDeleted()
        {
            // Arrange
            int id = 1;
            _mockService.Setup(service => service.DeleteAdditionalInfoAsync(id)).ReturnsAsync(1); // Simulate success

            // Act
            var result = await landlordAdditionalInfoController.Delete(id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<LandlordAdditionalInfo>>(result);
            Assert.IsType<OkResult>(actionResult.Result); // Expect Ok
        }



    }

}
