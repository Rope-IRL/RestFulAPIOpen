using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.DTOs;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LandLordController(ILandlordService service) : Controller
{
    [HttpGet("{pageNumber:int?}/{pageSize:int?}")]
    public async Task<IEnumerable<Landlord>> Get(int pageNumber = 1, int pageSize = 20)
    {
        return await service.GetFullByPageAsync(pageNumber, pageSize);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Landlord>> GetSingle(int id)
    {
        var landLord = await service.GetByIdAsync(id);
        if (landLord == null)
        {
            return NotFound();
        }
        return landLord;
    }

    [HttpPut]
    public async Task<ActionResult<Landlord>> Put([FromBody] Landlord landLord)
    {
        if (landLord == null)
        {
            return BadRequest();
        }
        await service.AddAsync(landLord);
        return Ok(landLord);
    }

    [HttpPost]
    public async Task<ActionResult<Landlord>> Post([FromBody] Landlord landLord)
    {
        var res = await service.UpdateAsync(landLord);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(landLord);
    }

    [Authorize(Roles = "landlord")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Landlord>> Delete(int id)
    {
        var res = await service.DeleteAsync(id);
        if (res == 0)
        {
            return NotFound();
        }
        if (Request.Cookies.ContainsKey(".AspNetCore.Application.Id"))
        {
            HttpContext.Response.Cookies.Delete(".AspNetCore.Application.Id");
        }
        return Redirect("/");
    }

    [HttpPost("login")]
    public async Task<ActionResult<LandlordDTO>> Auth([FromBody] LandlordDTO landlordDTO)
    {

        LandlordDTO landlordDto = await service.GetToken(landlordDTO);

        string token = landlordDto.Token;

        if (token == null)
        {
            return Unauthorized();
        }
        
        HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", token, new CookieOptions
        {
            MaxAge = TimeSpan.FromMinutes(60)
        });

        return Ok(landlordDTO);
    }
    
    [HttpGet]
    [Route("refreshToken")]
    [Authorize(Roles = "landlord")]
    public async Task<ActionResult<LandlordDTO>> RefreshToken()
    {
        int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id").Value);
        Landlord landlord = await service.GetByIdAsync(userId);
        LandlordDTO landlordDTO = new LandlordDTO
        {
            Id = landlord.Id,
            Email = landlord.Email,
            Login = landlord.Login,
            Password = landlord.HashedPassword,
            Name = landlord.AdditionalInfo == null ? landlord.Email : landlord.AdditionalInfo.Name
        };

        return Ok(landlordDTO);
    }

    [HttpGet]
    [Route("logout")]
    [Authorize(Roles ="landlord")]
    public async Task<ActionResult> LogOut()
    {
        if (Request.Cookies.ContainsKey(".AspNetCore.Application.Id"))
        {
            HttpContext.Response.Cookies.Delete(".AspNetCore.Application.Id");
        }

        return Ok();
    }
}