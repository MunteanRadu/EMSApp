using EMSApp.Application.Auth;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace EMSApp.Api;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (string.IsNullOrWhiteSpace(loginRequest.Username) ||
            string.IsNullOrWhiteSpace(loginRequest.Password))
            return BadRequest("Username and password are required.");

        var token = await _authService.LoginAsync(loginRequest.Username, loginRequest.Password);

        return token is null
            ? Unauthorized("Invalid credentials.")
                : Ok(new {accessToken = token});
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest dto)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var token = await _authService.RegisterAsync(dto.Username, dto.Email,
                                              dto.Password);
        return Created("/auth/login", new { accessToken = token });
    }
}
