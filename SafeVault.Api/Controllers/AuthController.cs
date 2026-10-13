using Microsoft.AspNetCore.Mvc;
using SafeVault.Api.Models;
using SafeVault.Api.Security;

namespace SafeVault.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthenticationService _auth;
    private readonly JwtService _jwt;
    private readonly ILogger<AuthController> _logger;

    public AuthController(
        AuthenticationService auth,
        JwtService jwt,
        ILogger<AuthController> logger)
    {
        _auth = auth;
        _jwt = jwt;
        _logger = logger;
    }

    [HttpPost("register")]
    public IActionResult Register(
        RegisterRequest request)
    {
        bool result =
            _auth.Register(
                request.Username,
                request.Password,
                request.Role);

        if (!result)
            return BadRequest(
                "User already exists");

        _logger.LogInformation(
            "User registered: {User}",
            request.Username);

        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login(
        LoginRequest request)
    {
        bool valid =
            _auth.ValidateUser(
                request.Username,
                request.Password);

        if (!valid)
            return Unauthorized();

        string role =
            _auth.GetRole(
                request.Username)!;

        string token =
            _jwt.GenerateToken(
                request.Username,
                role);

        _logger.LogInformation(
            "User logged in: {User}",
            request.Username);

        return Ok(new
        {
            Token = token
        });
    }
}