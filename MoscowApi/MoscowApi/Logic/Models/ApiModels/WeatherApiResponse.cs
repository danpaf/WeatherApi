namespace MoscowApi.Logic.Models.ApiModels;

public class WeatherApiResponse
{
    public Location location { get; set; }
    public Forecast forecast { get; set; }
}