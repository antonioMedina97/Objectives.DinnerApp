﻿using MHTester.Application.Common.Errors;
using MHTester.Application.Common.Interfaces.Authentication;
using MHTester.Application.Common.Interfaces.Persistence;
using MHTester.Domain.Entities;
using OneOf;

namespace MHTester.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) : IAuthenticationService
{
    public OneOf<AuthenticationResult, IError> Register(string firstName, string lastName, string email, string password)
    {
        if (userRepository.GetUserByEmail(email) is not null)
        {
            return new DuplicateEmailError();
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

    public AuthenticationResult Login(string email, string password)
    {
        if (userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exits");
        }

        if (user.Password != password)
        {
            throw new Exception("Invalid password");
        }
        
        var token = jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token
        );
    }
}