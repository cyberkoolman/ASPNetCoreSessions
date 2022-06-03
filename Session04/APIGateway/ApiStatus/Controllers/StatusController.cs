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
        var random = new Random();
        var list = new List<StatusCodeResult> { Ok(), NotFound() };
        int index = random.Next(list.Count);

        return list[index];
    }
}
