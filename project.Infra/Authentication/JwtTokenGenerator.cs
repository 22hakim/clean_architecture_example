using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using project.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace project.Infra.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public JwtTokenGenerator()
    {
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
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret-key")),
            SecurityAlgorithms.HmacSha256);

        var sercurityToken = new JwtSecurityToken(
            issuer: "we will see", // from where the token comes 
            expires : DateTime.Today.AddDays(2),
            claims: claims,
            signingCredentials: signInCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(sercurityToken);
    }
}

