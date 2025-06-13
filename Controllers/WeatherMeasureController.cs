using Microsoft.AspNetCore.Mvc;
using weather_station_back.Models;
using weather_station_back.Services;

namespace weather_station_back.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherMeasureController : ControllerBase
{
    private readonly WeatherMeasureService _measureService;

    public WeatherMeasureController(WeatherMeasureService measureService)
    {
        _measureService = measureService;
    }

    [HttpPost]
    public IActionResult Post([FromBody] WeatherMeasure measure)
    {
        var result = _measureService.AddWeatherMeasure(measure);

       
        if (result)
        {
            return Ok(new { message = "Weather measure added successfully!" });
        }
        else
        {
            return BadRequest(new { message = "Failed to add weather measure." });
        }
    }
}