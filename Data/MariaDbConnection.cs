using MySql.Data.MySqlClient;

namespace weather_station_back.Data;

public class MariaDbConnection
{
    private readonly string _connectionString;

    public MariaDbConnection()
    {
        // Obtiene la cadena de conexión de las variables de entorno
        _connectionString = Environment.GetEnvironmentVariable("MARIADB_CONNECTION") 
            ?? throw new InvalidOperationException("La variable de entorno 'MARIADB_CONNECTION' no está configurada");
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}