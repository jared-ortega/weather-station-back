// namespace weather_station_back.Models;

// public record WeatherMeasure(DateTime Timestamp, double Temperature, double Humidity)
// {
//     // Aquí puedes agregar propiedades calculadas si es necesario
// }

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weather_station_back.Models
{
    [Table("WeatherData")]
    public class WeatherMeasure
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        //[Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Required]
        [Column("location")]
        [MaxLength(255)]
        public string? Location { get; set; }

        [Required]
        [Column("temperature", TypeName = "decimal(5,2)")]
        public decimal Temperature { get; set; }

        //[Required]
        [Column("pressure", TypeName = "decimal(6,2)")]
        public decimal Pressure { get; set; }

        //[Required]
        [Column("humidity", TypeName = "decimal(6,2)")]
        public decimal Humidity { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
