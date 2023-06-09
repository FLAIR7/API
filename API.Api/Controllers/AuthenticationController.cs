using API.Application.Services.Authentication;
using API.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers;

[ApiController]
[Route("v1/api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
        => (_authenticationService) = authenticationService;

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(request.Name, request.Email, request.Password);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Name,
            authResult.User.Email,
            authResult.Token
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);

         var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Name,
            authResult.User.Email,
            authResult.Token
        );

        return Ok(response);
    }

}