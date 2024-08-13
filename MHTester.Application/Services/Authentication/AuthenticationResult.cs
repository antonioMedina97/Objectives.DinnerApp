using MHTester.Domain.Entities;

namespace MHTester.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
    );