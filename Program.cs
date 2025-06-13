using Microsoft.EntityFrameworkCore;
using weather_station_back.Data;
using weather_station_back.Services;

var builder = WebApplication.CreateBuilder(args);

// Cargar configuración y servicios
DotNetEnv.Env.Load();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("MARIADB_CONNECTION");
    if (string.IsNullOrEmpty(connectionString))
        throw new InvalidOperationException("La cadena de conexión no está configurada");

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddScoped<WeatherMeasureService>();

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