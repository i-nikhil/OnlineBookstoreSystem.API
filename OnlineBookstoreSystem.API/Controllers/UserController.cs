using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreSystem.API.DTOs;
using OnlineBookstoreSystem.API.Models;
using OnlineBookstoreSystem.API.Services;

namespace OnlineBookstoreSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    /// <summary>
    /// Dependency injecting service layer
    /// </summary>
    /// <param name="userService"></param>
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Register a new user
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult RegisterUser(RegisterUserRequest request)
    {
        var user = new User
        {
            Name = request.Name,
            Email = request.Email
        };
        _userService.RegisterUser(user);
        return Ok();
    }

    /// <summary>
    /// Fetch all registered users
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }
}
