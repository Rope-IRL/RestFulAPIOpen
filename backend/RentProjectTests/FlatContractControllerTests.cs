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

    public class FlatContractControllerTests
    {
        private readonly Mock<IFlatContractService> _mockService;
        private readonly Mock<IFlatContract> _mockRepo;
        private readonly FlatContractController flatController;

        public FlatContractControllerTests()
        {
            _mockService = new Mock<IFlatContractService>();
            flatController = new FlatContractController(_mockService.Object);
            _mockRepo = new Mock<IFlatContract>();

        }


        [Fact]
        public async Task Get_ReturnsListOfFlatContracts()
        {
            // Arrange
            int pageNumber = 1;
            int pageSize = 20;
            var contracts = new List<FlatContract>
            {
                new FlatContract { Id = 1, FlatId = 1, LesseeId = 1, LandlordId = 2, 
                    StartDate = new DateOnly(2024, 1, 1), EndDate = new DateOnly(2024, 12, 31), Cost = 100 },
                new FlatContract { Id = 2, FlatId = 2, LesseeId = 2, LandlordId = 3, 
                    StartDate = new DateOnly(2024, 2, 1), EndDate = new DateOnly(2024, 11, 30), Cost = 150 }
            };

            _mockService.Setup(service => service.GetInfoByPage(pageNumber, pageSize)).ReturnsAsync(contracts);

            // Act
            var result = await flatController.Get(pageNumber, pageSize);

            // Assert
            var actionResult = Assert.IsType<List<FlatContract>>(result);
            Assert.NotEmpty(actionResult); // Ensure the list is not empty
        }

        [Fact]
        public async Task GetSingle_ReturnsNotFound_WhenContractIsNotFound()
        {
            // Arrange
            int contractId = 1;
            _mockService.Setup(service => service.GetFlatContractByIdAsync(contractId)).ReturnsAsync((FlatContract)null);

            // Act
            var result = await flatController.GetSingle(contractId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<FlatContract>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result); // Expect NotFound if contract is null
        }

        [Fact]
        public async Task GetSingle_ReturnsContract_WhenContractIsFound()
        {
            // Arrange
            int contractId = 1;
            var contract = new FlatContract { Id = contractId, FlatId = 1, LesseeId = 1, LandlordId = 2, StartDate = new DateOnly(2024, 1, 1), EndDate = new DateOnly(2024, 12, 31), Cost = 100 };
            _mockService.Setup(service => service.GetFlatContractByIdAsync(contractId)).ReturnsAsync(contract);

            // Act
            var result = await flatController.GetSingle(contractId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<FlatContract>>(result);
            var returnValue = Assert.IsType<FlatContract>(actionResult.Value); // Ensure the returned value is a FlatContract
            Assert.Equal(contractId, returnValue.Id); // Assert the correct contract is returned
        }

        [Fact]
        public async Task Put_ReturnsBadRequest_WhenContractIsNull()
        {
            // Act
            var result = await flatController.Put(null);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result); // Expect BadRequest when contract is null
        }

        [Fact]
        public async Task Put_ReturnsOk_WhenContractIsValid()
        {
            // Arrange
            var contract = new FlatContract { Id = 1, FlatId = 1, LesseeId = 1, LandlordId = 2, StartDate = new DateOnly(2024, 1, 1), EndDate = new DateOnly(2024, 12, 31), Cost = 100 };
            _mockService.Setup(service => service.AddFlatContractAsync(contract)).ReturnsAsync(1);

            // Act
            var result = await flatController.Put(contract);

            // Assert
            var actionResult = Assert.IsType<ActionResult<FlatContract>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result); // Expect Ok if contract update is successful
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenContractIsNotFound()
        {
            // Arrange
            int contractId = 1;
            _mockService.Setup(service => service.DeleteFlatContractAsync(contractId)).ReturnsAsync(0); // Simulate deletion failure

            // Act
            var result = await flatController.Delete(contractId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<FlatContract>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result); // Expect NotFound if contract is not found
        }

        [Fact]
        public async Task Delete_ReturnsOk_WhenContractDeletedSuccessfully()
        {
            // Arrange
            int contractId = 1;
            _mockService.Setup(service => service.DeleteFlatContractAsync(contractId)).ReturnsAsync(1); // Simulate successful deletion

            // Act
            var result = await flatController.Delete(contractId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<FlatContract>>(result);
            Assert.IsType<OkResult>(actionResult.Result); // Expect Ok if contract is deleted successfully
        }


    }
}
