using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MVCClient.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _conf;
    private readonly ITokenService _tokenService;

    public HomeController(ILogger<HomeController> logger, IConfiguration conf, ITokenService tokenService)
    {
        _logger = logger;
        _conf = conf;
        _tokenService = tokenService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> Todo()
    {
        using var client = new HttpClient();
        var token = await _tokenService.GetToken("todoapi.read");
        client.SetBearerToken(token.AccessToken);   // SetBearerToken from IdenityModel

        var apiEndpoint = _conf["API:endpoint"];
        var result = await client.GetAsync(apiEndpoint);

        if (result.IsSuccessStatusCode)
        {
            var model = await result.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<TodoItem>>(model);

            return View(data);
        }

        throw new Exception("Unable to fetch data");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
