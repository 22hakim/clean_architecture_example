using System;
namespace project.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userID, string firstName, string lastName);
}

