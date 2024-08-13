using MHTester.Domain.Entities;

namespace MHTester.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}