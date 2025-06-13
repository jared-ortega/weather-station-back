// using Microsoft.AspNetCore.Builder;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;
// using DotNetEnv;
// using weather_station_back.Services;

// var builder = WebApplication.CreateBuilder(args);

// // Cargar variables de entorno desde el archivo .env
// Env.Load();

// // Configuración de servicios
// builder.Services.AddControllers(); // Configura el soporte para controladores
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// builder.Services.AddSingleton<WeatherService>(); // Registro del servicio WeatherService

// var app = builder.Build();

// // Configuración del pipeline de solicitudes HTTP
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseAuthorization();
// app.MapControllers(); // Configura el mapeo de controladores

// app.Run();
using Microsoft.EntityFrameworkCore;
using weather_station_back.Data;
using weather_station_back.Services;

var builder = WebApplication.CreateBuilder(args);

// Cargar variables de entorno desde el archivo .env
DotNetEnv.Env.Load();

// Configuración de servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MariaDbConnection>(); // Registro de la clase MariaDbConnection
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("MARIADB_CONNECTION");
    if (string.IsNullOrEmpty(connectionString))
        throw new InvalidOperationException("La cadena de conexión no está configurada");

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddSingleton<WeatherService>();

var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();