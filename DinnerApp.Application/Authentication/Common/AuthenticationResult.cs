using DinnerApp.Domain.Entities;

namespace DinnerApp.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);