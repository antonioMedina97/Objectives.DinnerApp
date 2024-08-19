using ErrorOr;
using MapsterMapper;
using MediatR;
using MHTester.Application.Authentication.Commands.Register;
using MHTester.Application.Authentication.Common;
using MHTester.Application.Authentication.Queries.Login;
using MHTester.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MHTester.api.Controllers;


[Route("auth")]
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
