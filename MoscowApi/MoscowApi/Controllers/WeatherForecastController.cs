using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MoscowApi.Database;
using MoscowApi.Logic;
using MoscowApi.Utils.Http.Models;

namespace MoscowApi.Controllers
{
    
    [ApiController]
    [Route("weather")]
    public class MoscowWeatherController : ControllerBase
    {
        private readonly ILogger<MoscowWeatherController> _logger;
        private readonly WeatherLogic _weatherLogic;

        public MoscowWeatherController(ILogger<MoscowWeatherController> logger, WeatherLogic weatherLogic)
        {
            _logger = logger;
            _weatherLogic = weatherLogic;
        }
        
        [HttpGet("GetMoskowWeather")]
        [Authorize]
        public async Task<IActionResult> GetMoskowWeatherAsync(DateOnly date)
        {
            if (date == DateOnly.MinValue)
            {
                return new FailedResponseModel("Invalid input date", 400);
            }
            var result = await _weatherLogic.GetMoscowWeatherAsync(date);

            return GenericResponseModel.FromLogicResult(result);
        }
        [HttpPost("SaveMoskowWeather")]
        [Authorize]
        public async Task<IActionResult> SaveMoskowWeatherAsync(DateOnly date)
        {
            if (date == DateOnly.MinValue)
            {
                return new FailedResponseModel("Invalid input date", 400);
            }
            var result = await _weatherLogic.SaveMoskowWeatherAsync(date);
            return GenericResponseModel.FromLogicResult(result);
        }

    }
}