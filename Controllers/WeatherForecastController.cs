using Microsoft.AspNetCore.Mvc;
using weather_station_back.Models;
using weather_station_back.Services;

namespace weather_station_back.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly WeatherService _weatherService;

    public WeatherForecastController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return _weatherService.GetWeatherForecasts();
    }
}