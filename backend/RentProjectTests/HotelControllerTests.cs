using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Application.Services;
using RestFulAPI.Controllers;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;
using Xunit.Sdk;

namespace RentProjectTests;

public class HotelControllerTests
{
    private readonly Mock<IHotelService> _mockService;
    private readonly Mock<IHotel> _mockRepo;
    private readonly HotelController hotelController;

    public HotelControllerTests()
    {
        _mockService = new Mock<IHotelService>();
        hotelController = new HotelController(_mockService.Object);
        _mockRepo = new Mock<IHotel>();
    }

    [Fact]
    public async Task Get_ReturnsListOfHotels()
    {
        // Arrange
        int pageNumber = 1;
        int pageSize = 20;
        var hotels = new List<Hotel>
        {
            new Hotel { Id = 1, Header = "Hotel A", City = "City A", AverageMark = 4.5m },
            new Hotel { Id = 2, Header = "Hotel B", City = "City B", AverageMark = 3.8m }
        };

        _mockService.Setup(service => service.GetFullByPageAsync(pageNumber, pageSize)).ReturnsAsync(hotels);

        // Act
        var result = await hotelController.Get(pageNumber, pageSize);

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<Hotel>>>(result);
        var returnValue = Assert.IsType<List<Hotel>>(actionResult.Value);
        Assert.NotEmpty(returnValue); // Ensure the list is not empty
    }

    [Fact]
    public async Task GetSingle_ReturnsNotFound_WhenHotelIsNotFound()
    {
        // Arrange
        int hotelId = 1;
        _mockService.Setup(service => service.GetHotelById(hotelId)).ReturnsAsync((Hotel)null);

        // Act
        var result = await hotelController.GetSingle(hotelId);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Hotel>>(result);
        Assert.IsType<NotFoundResult>(actionResult.Result); // Expect NotFound if hotel is null
    }

    [Fact]
    public async Task GetSingle_ReturnsHotel_WhenHotelIsFound()
    {
        // Arrange
        int hotelId = 1;
        var hotel = new Hotel
        {
            Id = hotelId,
            Header = "Hotel A",
            Description = "A description",
            AverageMark = 4.5m,
            City = "City A",
            Address = "Address A"
        };
        _mockService.Setup(service => service.GetHotelById(hotelId)).ReturnsAsync(hotel);

        // Act
        var result = await hotelController.GetSingle(hotelId);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Hotel>>(result);
        var returnValue = Assert.IsType<Hotel>(actionResult.Value); // Ensure the returned value is a Hotel
        Assert.Equal(hotelId, returnValue.Id); // Assert the correct hotel is returned
    }

    [Fact]
    public async Task Put_ReturnsBadRequest_WhenHotelIsNull()
    {
        // Act
        var result = await hotelController.Put(null);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result); // Expect BadRequest when hotel is null
    }

    [Fact]
    public async Task Put_ReturnsOk_WhenHotelIsValid()
    {
        // Arrange
        var hotel = new Hotel { Id = 1, Header = "Hotel A", City = "City A", AverageMark = 4.5m };
        _mockService.Setup(service => service.AddHotel(hotel)).ReturnsAsync(1);

        // Act
        var result = await hotelController.Put(hotel);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Hotel>>(result);
        Assert.IsType<OkObjectResult>(actionResult.Result); // Expect Ok if hotel update is successful
    }

    [Fact]
    public async Task Delete_ReturnsNotFound_WhenHotelIsNotFound()
    {
        // Arrange
        int hotelId = 1;
        _mockService.Setup(service => service.DeleteHotel(hotelId)).ReturnsAsync(0); // Simulate deletion failure

        // Act
        var result = await hotelController.Delete(hotelId);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Hotel>>(result);
        Assert.IsType<NotFoundResult>(actionResult.Result); // Expect NotFound if hotel is not found
    }

    [Fact]
    public async Task Delete_ReturnsOk_WhenHotelDeletedSuccessfully()
    {
        // Arrange
        int hotelId = 1;
        _mockService.Setup(service => service.DeleteHotel(hotelId)).ReturnsAsync(1); // Simulate successful deletion

        // Act
        var result = await hotelController.Delete(hotelId);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Hotel>>(result);
        Assert.IsType<OkResult>(actionResult.Result); // Expect Ok if hotel is deleted successfully
    }

}