using Microsoft.AspNetCore.Mvc;


namespace WebApiIdentity.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
      _logger = logger;
    }

    [HttpGet("list",Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
      })
      .ToArray();
    }

    // api/users/1/profile
    // api/User/Profile/1 // mvc
    // nested route 
    // api/makaleler/5/yorumlar/3
    // Makaleler/Yorum?makaleId=5&yorumId=3

    [HttpGet("getBy")]
    public IActionResult GetById([FromQuery] string id)
    {
      return Ok();
    }


    [HttpGet("test/{id}")]
    public IActionResult Test(string id)
    {
      return Ok();
    }
  }
}