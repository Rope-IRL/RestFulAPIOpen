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
    public class FlatControllerTests
    {
        private readonly Mock<IFlatService> _mockService;
        private readonly Mock<IFlat> _mockRepo;
        private readonly FlatController flatController;

        public FlatControllerTests()
        {
            _mockService = new Mock<IFlatService>();
            flatController = new FlatController(_mockService.Object);
            _mockRepo = new Mock<IFlat>();
        }

        [Fact]
        public async Task Get_NumberBiggerThanNumberOfFlatsInList_ReturnsRightNumberOfFlats()
        {
            //Arrange
            int pageNumber = 1;
            int pageSize = 10;

            Flat flat1 = new Flat
            {
                Id = 1,
                Header = "1",
                Description = "1",
                AverageMark = 2.0m,
                City = "city_1",
                Address = "address_1",
                NumberOfFloors = 1,
                NumberOfRooms = 1,
                IsBathroomAvailable = true,
                IsWiFiAvailable = true,
                CostPerDay = 1,
                LlId = 1,
            };

            Flat flat2 = new Flat
            {
                Id = 2,
                Header = "1",
                Description = "1",
                AverageMark = 2.0m,
                City = "city_1",
                Address = "address_1",
                NumberOfFloors = 1,
                NumberOfRooms = 1,
                IsBathroomAvailable = true,
                IsWiFiAvailable = true,
                CostPerDay = 1,
                LlId = 1,
            };

            List<Flat> flats = new List<Flat>
            {
                flat1,
                flat2,
            };

            _mockService.Setup(s => s.GetFlats(pageNumber, pageSize)).ReturnsAsync(flats);
            //var act = async () => await flatController.Get(pageNumber, pageSize);

            //Act
            var res = await flatController.Get(pageNumber, pageSize);

            //Assert
            Assert.Equal(res.Value.Count, 2);
        }

        [Fact]
        public async Task GetSingle_IdWhichNotExist_ReturnNotFound()
        {
            //Arrange
            int flatId = 3;

            Flat flat1 = new Flat
            {
                Id = 1,
                Header = "1",
                Description = "1",
                AverageMark = 2.0m,
                City = "city_1",
                Address = "address_1",
                NumberOfFloors = 1,
                NumberOfRooms = 1,
                IsBathroomAvailable = true,
                IsWiFiAvailable = true,
                CostPerDay = 1,
                LlId = 1,
            };

            Flat flat2 = new Flat
            {
                Id = 2,
                Header = "1",
                Description = "1",
                AverageMark = 2.0m,
                City = "city_1",
                Address = "address_1",
                NumberOfFloors = 1,
                NumberOfRooms = 1,
                IsBathroomAvailable = true,
                IsWiFiAvailable = true,
                CostPerDay = 1,
                LlId = 1,
            };

            List<Flat> flats = new List<Flat>
            {
                flat1,
                flat2,
            };

            _mockService.Setup(s => s.GetFlatById(flatId)).ReturnsAsync((Flat)null);
            //var act = async () => await flatController.Get(pageNumber, pageSize);

            //Act
            var res = await flatController.GetSingle(flatId);

            //Assert
            var actionResult = Assert.IsType<ActionResult<Flat>>(res);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetSingle_IdWhichExist_ReturnFlat()
        {
            //Arrange
            int flatId = 1;

            Flat flat1 = new Flat
            {
                Id = 1,
                Header = "1",
                Description = "1",
                AverageMark = 2.0m,
                City = "city_1",
                Address = "address_1",
                NumberOfFloors = 1,
                NumberOfRooms = 1,
                IsBathroomAvailable = true,
                IsWiFiAvailable = true,
                CostPerDay = 1,
                LlId = 1,
            };

            Flat flat2 = new Flat
            {
                Id = 2,
                Header = "1",
                Description = "1",
                AverageMark = 2.0m,
                City = "city_1",
                Address = "address_1",
                NumberOfFloors = 1,
                NumberOfRooms = 1,
                IsBathroomAvailable = true,
                IsWiFiAvailable = true,
                CostPerDay = 1,
                LlId = 1,
            };

            List<Flat> flats = new List<Flat>
            {
                flat1,
                flat2,
            };

            _mockService.Setup(s => s.GetFlatById(flatId)).ReturnsAsync(flat1);
            //var act = async () => await flatController.Get(pageNumber, pageSize);

            //Act
            var res = await flatController.GetSingle(flatId);

            //Assert
            Assert.Equal(res.Value, flat1);
        }

        [Fact]
        public async Task Put_Flat_ReturnFlat()
        {
            //Arrange

            Flat flat1 = new Flat
            {
                Id = 1,
                Header = "1",
                Description = "1",
                AverageMark = 2.0m,
                City = "city_1",
                Address = "address_1",
                NumberOfFloors = 1,
                NumberOfRooms = 1,
                IsBathroomAvailable = true,
                IsWiFiAvailable = true,
                CostPerDay = 1,
                LlId = 1,
            };

            Flat flat2 = new Flat
            {
                Id = 2,
                Header = "1",
                Description = "1",
                AverageMark = 2.0m,
                City = "city_1",
                Address = "address_1",
                NumberOfFloors = 1,
                NumberOfRooms = 1,
                IsBathroomAvailable = true,
                IsWiFiAvailable = true,
                CostPerDay = 1,
                LlId = 1,
            };


            _mockService.Setup(s => s.AddFlat(flat1)).ReturnsAsync(1);
            //var act = async () => await flatController.Get(pageNumber, pageSize);

            //Act
            var res = await flatController.Put(flat1);

            //Assert
            var actionResult = Assert.IsType<ActionResult<Flat>>(res);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task Post_UpdateNotExistingFlat_ReturnNotFound()
        {
            //Arrange

            Flat flat1 = new Flat
            {
                Id = 1,
                Header = "1",
                Description = "1",
                AverageMark = 2.0m,
                City = "city_1",
                Address = "address_1",
                NumberOfFloors = 1,
                NumberOfRooms = 1,
                IsBathroomAvailable = true,
                IsWiFiAvailable = true,
                CostPerDay = 1,
                LlId = 1,
            };

            Flat flat2 = new Flat
            {
                Id = 2,
                Header = "1",
                Description = "1",
                AverageMark = 2.0m,
                City = "city_1",
                Address = "address_1",
                NumberOfFloors = 1,
                NumberOfRooms = 1,
                IsBathroomAvailable = true,
                IsWiFiAvailable = true,
                CostPerDay = 1,
                LlId = 1,
            };


            _mockService.Setup(s => s.UpdateFlat(flat1)).ReturnsAsync(0);
            //var act = async () => await flatController.Get(pageNumber, pageSize);

            //Act
            var res = await flatController.Post(flat1);

            //Assert
            var actionResult = Assert.IsType<ActionResult<Flat>>(res);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task Post_UpdateExistingFlat_ReturnOk()
        {
            //Arrange

            Flat flat1 = new Flat
            {
                Id = 1,
                Header = "1",
                Description = "1",
                AverageMark = 2.0m,
                City = "city_1",
                Address = "address_1",
                NumberOfFloors = 1,
                NumberOfRooms = 1,
                IsBathroomAvailable = true,
                IsWiFiAvailable = true,
                CostPerDay = 1,
                LlId = 1,
            };

            Flat flat2 = new Flat
            {
                Id = 2,
                Header = "1",
                Description = "1",
                AverageMark = 2.0m,
                City = "city_1",
                Address = "address_1",
                NumberOfFloors = 1,
                NumberOfRooms = 1,
                IsBathroomAvailable = true,
                IsWiFiAvailable = true,
                CostPerDay = 1,
                LlId = 1,
            };


            _mockService.Setup(s => s.UpdateFlat(flat2)).ReturnsAsync(1);
            //var act = async () => await flatController.Get(pageNumber, pageSize);

            //Act
            var res = await flatController.Post(flat2);

            //Assert
            var actionResult = Assert.IsType<ActionResult<Flat>>(res);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenFlatIsNotFound()
        {
            // Arrange
            int flatId = 1;
            _mockService.Setup(service => service.DeleteFlat(flatId)).ReturnsAsync(0); // Simulate a failed delete (flat not found)

            // Act
            var result = await flatController.Delete(flatId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Flat>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result); // Check for NotFound result
        }

        [Fact]
        public async Task Delete_ReturnsOk_WhenFlatIsDeletedSuccessfully()
        {
            // Arrange
            int flatId = 1;
            _mockService.Setup(service => service.DeleteFlat(flatId)).ReturnsAsync(1); // Simulate successful deletion

            // Act
            var result = await flatController.Delete(flatId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Flat>>(result);
            Assert.IsType<OkResult>(actionResult.Result); // Check for Ok result
        }

        [Fact]
        public async Task GetFlatsByCity_ReturnsListOfFlats()
        {
            // Arrange
            string city = "Test City";
            var flats = new List<Flat> { new Flat { Id = 1, Header = "Flat in Test City" } };
            _mockService.Setup(service => service.GetByCity(city)).ReturnsAsync(flats);

            // Act
            var result = await flatController.GetFlatsByCity(city);

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<Flat>>>(result);
            var returnValue = Assert.IsType<List<Flat>>(actionResult.Value); // Ensure it's a List<Flat>
            Assert.NotEmpty(returnValue); // Ensure list is not empty
        }

        [Fact]
        public async Task GetFlatsByCityAndDate_ReturnsListOfFlats()
        {
            // Arrange
            string city = "Test City";
            var startDate = new DateOnly(2023, 1, 1);
            var endDate = new DateOnly(2023, 12, 31);
            var flats = new List<Flat> { new Flat { Id = 1, Header = "Flat in City and Date Range" } };
            _mockService.Setup(service => service.GetByDatesAndCity(startDate, endDate, city)).ReturnsAsync(flats);

            // Act
            var result = await flatController.GetFlatsByCityAndDate(city, startDate, endDate);

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<Flat>>>(result);
            var returnValue = Assert.IsType<List<Flat>>(actionResult.Value); // Ensure it's a List<Flat>
            Assert.NotEmpty(returnValue); // Ensure list is not empty
        }

    }
}