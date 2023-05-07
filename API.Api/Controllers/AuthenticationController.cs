using API.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers;

[ApiController]
[Route("v1/api/auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        return Ok(request);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        return Ok(request);
    }

}