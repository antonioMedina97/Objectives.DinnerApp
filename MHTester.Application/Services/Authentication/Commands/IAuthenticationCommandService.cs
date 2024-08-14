using ErrorOr;
using MHTester.Application.Services.Authentication.Common;

namespace MHTester.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}