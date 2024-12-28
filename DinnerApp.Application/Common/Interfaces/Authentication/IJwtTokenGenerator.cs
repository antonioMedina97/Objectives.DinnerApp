using DinnerApp.Domain.Entities;

namespace DinnerApp.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}