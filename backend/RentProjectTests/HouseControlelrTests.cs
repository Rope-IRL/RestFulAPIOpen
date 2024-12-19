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
    public class HouseControllerTests
    {

        private readonly Mock<IHouseService> _mockService;
        private readonly Mock<IHouse> _mockRepo;
        private readonly HouseController houseController;

        public HouseControllerTests()
        {
            _mockService = new Mock<IHouseService>();
            houseController = new HouseController(_mockService.Object);
            _mockRepo = new Mock<IHouse>();
        }

        [Fact]
        public async Task Get_ReturnsListOfHouses()
        {
            // Arrange
            int pageNumber = 1;
            int pageSize = 20;
            var houses = new List<House>
            {
                new House { Id = 1, City = "New York", Header = "Luxury House", AverageMark = 4.5M },
                new House { Id = 2, City = "Los Angeles", Header = "Cozy Villa", AverageMark = 4.7M }
            };

            _mockService.Setup(service => service.GetFullByPage(pageNumber, pageSize)).ReturnsAsync(houses);

            // Act
            var result = await houseController.Get(pageNumber, pageSize);

            // Assert
            var actionResult = Assert.IsType<List<House>>(result);
            Assert.NotEmpty(actionResult); // Ensure the list is not empty
        }

        [Fact]
        public async Task GetSingle_ReturnsNotFound_WhenHouseIsNotFound()
        {
            // Arrange
            int houseId = 1;
            _mockService.Setup(service => service.GetByIdAsync(houseId)).ReturnsAsync((House)null);

            // Act
            var result = await houseController.GetSingle(houseId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<House>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result); // Expect NotFound
        }

        [Fact]
        public async Task GetSingle_ReturnsHouse_WhenHouseIsFound()
        {
            // Arrange
            int houseId = 1;
            var house = new House { Id = houseId, City = "New York", Header = "Luxury House" };
            _mockService.Setup(service => service.GetByIdAsync(houseId)).ReturnsAsync(house);

            // Act
            var result = await houseController.GetSingle(houseId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<House>>(result);
            var returnValue = Assert.IsType<House>(actionResult.Value);
            Assert.Equal(houseId, returnValue.Id); // Assert the correct house is returned
        }

        [Fact]
        public async Task Put_ReturnsBadRequest_WhenHouseIsNull()
        {
            // Act
            var result = await houseController.Put(null);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result); // Expect BadRequest
        }

        [Fact]
        public async Task Put_ReturnsOk_WhenHouseIsValid()
        {
            // Arrange
            var house = new House { Id = 1, City = "New York", Header = "Luxury House" };
            _mockService.Setup(service => service.AddAsync(house)).ReturnsAsync(1);

            // Act
            var result = await houseController.Put(house);

            // Assert
            var actionResult = Assert.IsType<ActionResult<House>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result); // Expect Ok
        }

        [Fact]
        public async Task Post_ReturnsNotFound_WhenUpdateFails()
        {
            // Arrange
            var house = new House { Id = 1, City = "New York", Header = "Luxury House" };
            _mockService.Setup(service => service.UpdateAsync(house)).ReturnsAsync(0); // Simulate failure

            // Act
            var result = await houseController.Post(house);

            // Assert
            var actionResult = Assert.IsType<ActionResult<House>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result); // Expect NotFound
        }

        [Fact]
        public async Task Post_ReturnsOk_WhenHouseUpdatedSuccessfully()
        {
            // Arrange
            var house = new House { Id = 1, City = "New York", Header = "Luxury House" };
            _mockService.Setup(service => service.UpdateAsync(house)).ReturnsAsync(1); // Simulate success

            // Act
            var result = await houseController.Post(house);

            // Assert
            var actionResult = Assert.IsType<ActionResult<House>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result); // Expect Ok
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenHouseIsNotFound()
        {
            // Arrange
            int houseId = 1;
            _mockService.Setup(service => service.DeleteAsync(houseId)).ReturnsAsync(0); // Simulate failure

            // Act
            var result = await houseController.Delete(houseId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<House>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result); // Expect NotFound
        }

        [Fact]
        public async Task Delete_ReturnsOk_WhenHouseDeletedSuccessfully()
        {
            // Arrange
            int houseId = 1;
            _mockService.Setup(service => service.DeleteAsync(houseId)).ReturnsAsync(1); // Simulate success

            // Act
            var result = await houseController.Delete(houseId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<House>>(result);
            Assert.IsType<OkResult>(actionResult.Result); // Expect Ok
        }

        [Fact]
        public async Task GetHousesByDates_ReturnsListOfHouses()
        {
            // Arrange
            DateOnly startDate = DateOnly.FromDateTime(DateTime.Now);
            DateOnly endDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(1));
            var houses = new List<House>
            {
                new House { Id = 1, City = "New York", Header = "Luxury House" },
                new House { Id = 2, City = "Los Angeles", Header = "Cozy Villa" }
            };

            _mockService.Setup(service => service.GetByDates(startDate, endDate)).ReturnsAsync(houses);

            // Act
            var result = await houseController.GetHousesByDates(startDate, endDate);

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<House>>>(result);
            var returnValue = Assert.IsType<List<House>>(actionResult.Value);
            Assert.NotEmpty(returnValue);
        }


        [Fact]
        public async Task GetHousesByCity_ReturnsListOfHousesForCity()
        {
            // Arrange
            string city = "New York";
            var houses = new List<House>
            {
                new House { Id = 1, City = city, Header = "Luxury House" },
                new House { Id = 2, City = city, Header = "Cozy Villa" }
            };

            _mockService.Setup(service => service.GetByCity(city)).ReturnsAsync(houses);

            // Act
            var result = await houseController.GetHousesByCity(city);

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<House>>>(result);
            var returnValue = Assert.IsType<List<House>>(actionResult.Value);
            Assert.All(returnValue, h => Assert.Equal(city, h.City));
        }

    }
}
