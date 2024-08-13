using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MHTester.Application.Common.Interfaces.Authentication;
using MHTester.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MHTester.Infrastructure.Authentication;

public class JwtTokenGenerator(IDateTimeProvider _dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings = jwtOptions.Value;


    public string GenerateToken(Guid userId, string firstName, string lastName)
    {

        var signInCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
            );
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
            claims: claims,
            signingCredentials: signInCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}