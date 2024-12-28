using ErrorOr;
using MapsterMapper;
using MediatR;
using DinnerApp.Application.Authentication.Commands.Register;
using DinnerApp.Application.Authentication.Common;
using DinnerApp.Application.Authentication.Queries.Login;
using DinnerApp.Contracts.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinnerApp.Api.Controllers;


[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var command = _mapper.Map<RegisterCommand>(registerRequest);

        ErrorOr<AuthenticationResult> authenticationResult = await _mediator.Send(command);

        return authenticationResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResult>(authResult)),
            errors => Problem(errors)
        );
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {

        var query = _mapper.Map<LoginQuery>(loginRequest);

        var authenticationResult = await _mediator.Send(query);

        return authenticationResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResult>(authResult)),
            errors => Problem(errors)
        );
    }
}
