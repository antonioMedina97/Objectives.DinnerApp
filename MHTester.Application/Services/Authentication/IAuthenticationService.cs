using MHTester.Application.Common.Errors;
using FluentResults;

namespace MHTester.Application.Services.Authentication;

public interface IAuthenticationService
{
    Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    
    AuthenticationResult Login(string email, string password);
}