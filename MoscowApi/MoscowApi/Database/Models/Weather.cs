using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoscowApi.Database.Models;

[Table("weather")]
public class Weather
{
    [Key]
    public Guid Uid { get; init; }
    public DateOnly Date { get; set; }
    public double TemperatureC { get; set; }
    public double TemperatureF { get; set; }
}