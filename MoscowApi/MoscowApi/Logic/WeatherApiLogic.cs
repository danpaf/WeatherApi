using System.Net;
using MoscowApi.Database;
using MoscowApi.Logic.Models;
using MoscowApi.Logic.Models.ApiModels;
using RestSharp;

namespace MoscowApi.Logic;

public class WeatherApiLogic : BaseLogic
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationContext _db;
    private readonly WeatherApiLogic _weatherApiLogic;
    
    public WeatherApiLogic(IServiceScopeFactory scopeFactory, IConfiguration configuration) : base(scopeFactory)
    {
        _configuration = configuration;
        _db = Scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    }

    public async Task<GenericLogicResult> GetWeatherByDateAsync(DateOnly date)
    {
        var api = _configuration.GetSection("Api")["WeatherApi"];
        var client = new RestClient("https://api.weatherapi.com/v1/");

        var request = new RestRequest("history.json");
        request.AddQueryParameter("q", "Moscow");
        request.AddQueryParameter("dt", date.ToString("yyyy-MM-dd"));
        request.AddQueryParameter("key", api);

        var response = await client.ExecuteAsync<WeatherApiResponse>(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return new SuccessLogicResult
            {
                Result = response.Data
            };
        }

        return new FailedLogicResult
        {
            Result = response,
            Exception = response.ErrorException,
            HttpCode = HttpStatusCode.InternalServerError
        };


    }
}