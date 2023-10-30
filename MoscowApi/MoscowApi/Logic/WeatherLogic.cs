using MoscowApi.Database;
using MoscowApi.Database.Models;
using MoscowApi.Logic.Models;
using MoscowApi.Logic.Models.ApiModels;
using MoscowApi.Utils.Http.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace MoscowApi.Logic;

public class WeatherLogic : BaseLogic
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationContext _db;
    private readonly WeatherApiLogic _weatherApiLogic;


    public WeatherLogic(IServiceScopeFactory scopeFactory, IConfiguration configuration) : base(scopeFactory)
    {
        _configuration = configuration;
        _db = Scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        _weatherApiLogic = Scope.ServiceProvider.GetRequiredService<WeatherApiLogic>();
    }

    public async Task<GenericLogicResult> GetMoscowWeatherAsync(DateOnly date)
    {
        var response = await _weatherApiLogic.GetWeatherByDateAsync(date);

        if (!response.Status)
        {
            return response;
        }

        var maxTempC = ((WeatherApiResponse) response.Result!).forecast.forecastday.First().day.maxtemp_c;
        var maxTempF = ((WeatherApiResponse) response.Result!).forecast.forecastday.First().day.maxtemp_f;

        return new SuccessLogicResult
        {
            Result = new
            {
                MaxTempC = maxTempC,
                MaxTempF = maxTempF
            }
        };

    }

    public async Task<GenericLogicResult> SaveMoskowWeatherAsync(DateOnly date)
    {
        var response = await GetMoscowWeatherAsync(date);
        
        if (!response.Status)
        {
            return response;
        }
        var result = (dynamic) response.Result!; 
        var moscowWeather = new Weather()
        {
            Date = date,
            TemperatureC = result.MaxTempC,
            TemperatureF = result.MaxTempF,
            
        };
        if (_db.Weathers.Any(x => x.Date == date))
        {
            return new SuccessLogicResult
            {
                Result = new
                {
                    MaxTempC = result.MaxTempC,
                    MaxTempF = result.MaxTempF
                }
            };
        }
        _db.Weathers.Add(moscowWeather);
        await _db.SaveChangesAsync();

        return new SuccessLogicResult
        {
            Result = new
            {
                MaxTempC = result.MaxTempC,
                MaxTempF = result.MaxTempF
            }
        };

       
    }
}