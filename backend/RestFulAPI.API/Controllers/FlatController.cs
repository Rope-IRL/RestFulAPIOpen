using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlatController(IFlatService service) : Controller
{

    [HttpGet("{pageNumber:int?}/{pageSize:int?}")]
    public async Task<ActionResult<List<Flat>>> Get(int pageNumber = 1, int pageSize = 20)
    {
        return await service.GetFlats(pageNumber, pageSize);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Flat>> GetSingle(int id)
    {
        var flat = await service.GetFlatById(id);
        if (flat == null)
        {
            return NotFound();
        }
        return flat;
    }

    [Authorize(Roles = "landlord")]
    [HttpPut]
    public async Task<ActionResult<Flat>> Put([FromBody] Flat flat)
    {
        await service.AddFlat(flat);
        return Ok(flat);
    }

    [Authorize(Roles = "landlord")]
    [HttpPost]
    public async Task<ActionResult<Flat>> Post([FromBody] Flat flat)
    {
        var res = await service.UpdateFlat(flat);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(flat);
    }

    [Authorize(Roles = "landlord")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Flat>> Delete(int id)
    {
        var res = await service.DeleteFlat(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }

    [Authorize(Roles = "landlord")]
    [HttpGet("landlord")]
    public async Task<ActionResult<List<Flat>>> GetLandlordFlats()
    {
        int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id").Value);
        List<Flat> flats = await service.GetByLandlord(userId);
        return flats;
    }

    [HttpGet("filter/{startDate:datetime}/{endDate:datetime}")]
    public async Task<ActionResult<List<Flat>>> GetFlatsByDates(DateOnly startDate, DateOnly endDate)
    {
        List<Flat> flats = await service.GetByDates(startDate, endDate);

        return flats;
    }

    [HttpGet("filter/{city}")]
    public async Task<ActionResult<List<Flat>>> GetFlatsByCity(String city)
    {
        List<Flat> flats = await service.GetByCity(city);

        return flats;
    }

    [HttpGet("filter/{city}/{startDate:datetime}/{endDate:datetime}")]
    public async Task<ActionResult<List<Flat>>> GetFlatsByCityAndDate(String city, DateOnly startDate, DateOnly endDate)
    {
        List<Flat> flats = await service.GetByDatesAndCity(startDate, endDate, city);

        return flats;
    }
}
