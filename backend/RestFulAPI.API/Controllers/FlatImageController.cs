using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlatImageController(IFlatImageService service) : Controller
{
    [HttpGet("flatimages/{flatId:int}")]
    public async Task<ActionResult<FlatImage>> GetByFlatId(int flatId)
    {
        FlatImage images = await service.GetImageById(flatId);

        return Ok(images);
    }
}

