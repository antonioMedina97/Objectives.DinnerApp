using ErrorOr;
using MHTester.Application.Common.Interfaces.Authentication;
using MHTester.Application.Common.Interfaces.Persistence;
using MHTester.Application.Services.Authentication.Common;
using MHTester.Domain.Common.Errors;
using MHTester.Domain.Entities;

namespace MHTester.Application.Services.Authentication.Queries;

public class AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) : IAuthenticationQueryService
{
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        
        var token = jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token
        );
    }
}