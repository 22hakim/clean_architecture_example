using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using project.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using project.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace project.Infra.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtConfig _jwtConfig;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,
                             IOptions<JwtConfig> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtConfig = jwtOptions.Value;
    }

    public string GenerateToken(Guid userID, string firstName, string lastName)
    {
        var claims = new[]
        {
             new Claim(JwtRegisteredClaimNames.Sub, userID.ToString()),
             new Claim(JwtRegisteredClaimNames.GivenName, firstName),
             new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var signInCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret)),
            SecurityAlgorithms.HmacSha256);

        var sercurityToken = new JwtSecurityToken(
            issuer: _jwtConfig.Issuer,
            audience: _jwtConfig.Audience,
            expires: _dateTimeProvider.Now.AddHours(_jwtConfig.ExpiryMinutes),
            claims: claims,
            signingCredentials: signInCredentials
            ) ;

        return new JwtSecurityTokenHandler().WriteToken(sercurityToken);
    }
}

