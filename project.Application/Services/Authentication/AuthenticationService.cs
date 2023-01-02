using System;
using project.Application.Common.Interfaces.Authentication;
using project.Application.Common.Interfaces.Persistance;
using project.Domain.Entities;

namespace project.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string Email, string Password)
    {
        // validate that user exist
        if (_userRepository.GetUserByEmail(Email) is not User user)
        {
            throw new Exception("there is no user with given email");
        }
        // validate that password is true
        if(user.Password != Password)
        {
            throw new Exception("the given password isn't correct");
        }
        // create the token 
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,    
            token);
    }

    public AuthenticationResult Register(string FirstName,
        string LastName, string Email, string Password)
    {
        // check if user exist doesn't exist 
        if(_userRepository.GetUserByEmail(Email) is not null)
        {
            throw new Exception("the user already exist with given email");
        }
        // create user Unique ID
        var user = new User
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Password = Password
        };

        _userRepository.Add(user);

        // generate Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}

