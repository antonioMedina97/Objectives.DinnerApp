using MHTester.Domain.Entities;

namespace MHTester.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);