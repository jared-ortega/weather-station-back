using Microsoft.EntityFrameworkCore;
using weather_station_back.Models;

namespace weather_station_back.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    // Define las tablas de la base de datos como propiedades DbSet
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
}