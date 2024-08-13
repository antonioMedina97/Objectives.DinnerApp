using MHTester.Application.Services.Authentication;
using MHTester.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MHTester.api.Controllers;


[Route("auth")]
public class AuthenticationController : ApiController
{
    
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest)
    {
        var authenticationResult = _authenticationService.Register(
            registerRequest.FirstName,
            registerRequest.LastName,
            registerRequest.Email,
            registerRequest.Password);

        return authenticationResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        var authenticationResult = _authenticationService.Login(
            loginRequest.Email,
            loginRequest.Password);

        return authenticationResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }
}