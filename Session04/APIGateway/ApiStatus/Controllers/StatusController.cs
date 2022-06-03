using Microsoft.AspNetCore.Mvc;

namespace ApiStatus.Controllers;

[ApiController]
[Route("[controller]")]
public class StatusController : ControllerBase
{
    [HttpGet]
    [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
    public IActionResult Get()
    {
        return Random.Shared.Next(2) == 1 ? Ok() : NotFound();
    }
}