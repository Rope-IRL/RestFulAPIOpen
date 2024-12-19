using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HouseController(IHouseService service) : Controller
{
    [HttpGet("/api/[controller]/{pageNumber:int?}/{pageSize:int?}")]
    public async Task<IEnumerable<House>> Get(int pageNumber = 1, int pageSize = 20)
    {
        return await service.GetFullByPage(pageNumber, pageSize);
    }

    [HttpGet("/api/[controller]/{id:int}")]
    public async Task<ActionResult<House>> GetSingle(int id)
    {
        var house = await service.GetByIdAsync(id);
        if (house == null)
        {
            return NotFound();
        }
        return house;
    }

    [HttpPut]
    public async Task<ActionResult<House>> Put([FromBody] House house)
    {
        if (house == null)
        {
            return BadRequest();
        }
        await service.AddAsync(house);
        return Ok(house);
    }

    [HttpPost]
    public async Task<ActionResult<House>> Post([FromBody] House house)
    {
        var res = await service.UpdateAsync(house);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(house);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<House>> Delete(int id)
    {
        var res = await service.DeleteAsync(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }

    [Authorize(Roles = "landlord")]
    [HttpGet("landlord")]
    public async Task<ActionResult<List<House>>> GetLandlordHouses()
    {
        int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id").Value);
        List<House> houses = await service.GetByLandlord(userId);
        return houses;
    }

    [HttpGet("filter/{startDate:datetime}/{endDate:datetime}")]
    public async Task<ActionResult<List<House>>> GetHousesByDates(DateOnly startDate, DateOnly endDate)
    {
        List<House> houses = await service.GetByDates(startDate, endDate);

        return houses;
    }

    [HttpGet("filter/{city}")]
    public async Task<ActionResult<List<House>>> GetHousesByCity(string city)
    {
        List<House> houses = await service.GetByCity(city);

        return houses;
    }

    [HttpGet("filter/{city}/{startDate:datetime}/{endDate:datetime}")]
    public async Task<ActionResult<List<House>>> GetHousesByCityAndDate(String city, DateOnly startDate, DateOnly endDate)
    {
        List<House> houses = await service.GetByDatesAndCity(startDate, endDate, city);

        return houses;
    }
}
