using Microsoft.AspNetCore.Mvc;
using practice.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenService _tokenService;
    public AuthController(JwtTokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        //  Here you validate the credentials from DB/Identity
        if (request.Username == "user" && request.Password == "P123")
        {
            var token = _tokenService.GenerateToken(request.Username, "Admin");
            return Ok(new { token });
        }

        return Unauthorized("Invalid credentials");
    }
}
