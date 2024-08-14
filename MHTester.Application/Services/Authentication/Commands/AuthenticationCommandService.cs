using ErrorOr;
using MHTester.Application.Common.Interfaces.Authentication;
using MHTester.Application.Common.Interfaces.Persistence;
using MHTester.Application.Services.Authentication.Common;
using MHTester.Domain.Common.Errors;
using MHTester.Domain.Entities;

namespace MHTester.Application.Services.Authentication.Commands;

public class AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) : IAuthenticationCommandService
{
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if (userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        
        userRepository.Add(user);
        
        var token = jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token
            );
    }
}