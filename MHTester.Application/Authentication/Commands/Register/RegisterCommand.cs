using ErrorOr;
using MediatR;
using MHTester.Application.Authentication.Common;

namespace MHTester.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;