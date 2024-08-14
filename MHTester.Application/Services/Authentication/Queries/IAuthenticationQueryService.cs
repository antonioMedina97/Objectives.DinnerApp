using ErrorOr;
using MHTester.Application.Services.Authentication.Common;

namespace MHTester.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}