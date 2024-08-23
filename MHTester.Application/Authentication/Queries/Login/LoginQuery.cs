using ErrorOr;
using MediatR;
using MHTester.Application.Authentication.Common;

namespace MHTester.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;