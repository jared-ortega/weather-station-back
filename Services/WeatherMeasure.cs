using weather_station_back.Data;
using weather_station_back.Models;

namespace weather_station_back.Services;

public class WeatherMeasureService
{
    private readonly DatabaseContext _dbContext;

    public WeatherMeasureService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool AddWeatherMeasure(WeatherMeasure measure)
{
    try
    {
        _dbContext.WeatherMeasures.Add(measure);
        _dbContext.SaveChanges();
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al guardar medida: {ex.Message}");
        return false;
    }
}

}