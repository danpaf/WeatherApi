using Microsoft.AspNetCore.Mvc;
using MoscowApi.Services;
using MoscowApi.Utils.Http.Models;

namespace MoscowApi.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("create")]
    public async Task<IActionResult> CreateUser(string username,string password)
    {
        await _userService.CreateUserAsync("test", "test");
        return new SuccessResponseModel(new {Login="test", Password="test"});
    }
}