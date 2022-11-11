using System;
using project.Application.Common.Interfaces.Authentication;

namespace project.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string Email, string Password)
    {
        Guid userId = Guid.NewGuid();
        return new AuthenticationResult(
            userId,
            "firstname",
            "lastname",
            Email,
            "token");
    }

    public AuthenticationResult Register(string FirstName,
        string LastName, string Email, string Password)
    {
        // check if user exist

        // create user Unique ID

        // generate Token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, FirstName, LastName);

        return new AuthenticationResult(
            userId,
            FirstName,
            LastName,
            Email,
            token);
    }
}

