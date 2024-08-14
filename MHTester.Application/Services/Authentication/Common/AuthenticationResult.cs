using MHTester.Domain.Entities;

namespace MHTester.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
    );