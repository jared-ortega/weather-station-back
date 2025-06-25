using Microsoft.AspNetCore.Mvc;

namespace weather_station_back.Controllers;

[ApiController]
public class RootController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult Get()
    {
        return Ok(new {
            version = "1.0.0", 
            message = "Weather Station Backend Working on ARM Server."
        });
    }
}