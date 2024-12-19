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
    public class HouseContractControllerTests
    {
        private readonly Mock<IHouseContractService> _mockService;
        private readonly Mock<IHouseContract> _mockRepo;
        private readonly HouseContractController houseController;

        public HouseContractControllerTests()
        {
            _mockService = new Mock<IHouseContractService>();
            houseController = new HouseContractController(_mockService.Object);
            _mockRepo = new Mock<IHouseContract>();
        }

        [Fact]
        public async Task Get_ReturnsListOfHouseContracts()
        {
            // Arrange
            int pageNumber = 1;
            int pageSize = 20;
            var contracts = new List<HouseContract>
            {
                new HouseContract { Id = 1, Cost = 1000, HouseId = 1, LandlordId = 1, LesseeId = 2 },
                new HouseContract { Id = 2, Cost = 1500, HouseId = 2, LandlordId = 1, LesseeId = 3 }
            };

            _mockService.Setup(service => service.GetFullByPageAsync(pageNumber, pageSize)).ReturnsAsync(contracts);

            // Act
            var result = await houseController.Get(pageNumber, pageSize);

            // Assert
            var actionResult = Assert.IsType<List<HouseContract>>(result);
            Assert.NotEmpty(actionResult); // Ensure the list is not empty
        }

        [Fact]
        public async Task GetSingle_ReturnsNotFound_WhenContractIsNotFound()
        {
            // Arrange
            int contractId = 1;
            _mockService.Setup(service => service.GetByIdAsync(contractId)).ReturnsAsync((HouseContract)null);

            // Act
            var result = await houseController.GetSingle(contractId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<HouseContract>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result); // Expect NotFound if contract is null
        }

        [Fact]
        public async Task GetSingle_ReturnsContract_WhenContractIsFound()
        {
            // Arrange
            int contractId = 1;
            var contract = new HouseContract { Id = contractId, Cost = 1000, HouseId = 1, LandlordId = 1, LesseeId = 2 };
            _mockService.Setup(service => service.GetByIdAsync(contractId)).ReturnsAsync(contract);

            // Act
            var result = await houseController.GetSingle(contractId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<HouseContract>>(result);
            var returnValue = Assert.IsType<HouseContract>(actionResult.Value);
            Assert.Equal(contractId, returnValue.Id); // Assert the correct contract is returned
        }

        [Fact]
        public async Task Put_ReturnsBadRequest_WhenContractIsNull()
        {
            // Act
            var result = await houseController.Put(null);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result); // Expect BadRequest when contract is null
        }

        [Fact]
        public async Task Put_ReturnsOk_WhenContractIsValid()
        {
            // Arrange
            var contract = new HouseContract { Id = 1, Cost = 1000, HouseId = 1, LandlordId = 1, LesseeId = 2 };
            _mockService.Setup(service => service.AddAsync(contract)).ReturnsAsync(1);

            // Act
            var result = await houseController.Put(contract);

            // Assert
            var actionResult = Assert.IsType<ActionResult<HouseContract>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result); // Expect Ok if contract is successfully added
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenContractIsNotFound()
        {
            // Arrange
            int contractId = 1;
            _mockService.Setup(service => service.DeleteAsync(contractId)).ReturnsAsync(0); // Simulate deletion failure

            // Act
            var result = await houseController.Delete(contractId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<HouseContract>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result); // Expect NotFound if deletion fails
        }

        [Fact]
        public async Task Delete_ReturnsOk_WhenContractDeletedSuccessfully()
        {
            // Arrange
            int contractId = 1;
            _mockService.Setup(service => service.DeleteAsync(contractId)).ReturnsAsync(1); // Simulate successful deletion

            // Act
            var result = await houseController.Delete(contractId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<HouseContract>>(result);
            Assert.IsType<OkResult>(actionResult.Result); // Expect Ok if contract is successfully deleted
        }

        [Fact]
        public async Task GetContractsByYearAndMonth_ReturnsContractIds()
        {
            // Arrange
            int houseId = 1, year = 2024, month = 12;
            var contractIds = new HashSet<int> { 101, 102 };

            _mockService.Setup(service => service.GetHouseContractByYearAndMonthAndHouseId(houseId, year, month))
                        .ReturnsAsync(contractIds);

            // Act
            var result = await houseController.GetContractsByYearAndMonth(houseId, year, month);

            // Assert
            var actionResult = Assert.IsType<ActionResult<HashSet<int>>>(result);
            var returnValue = Assert.IsType<HashSet<int>>(actionResult.Value);
            Assert.NotEmpty(returnValue); // Ensure the returned IDs are not empty
        }


    }
}
