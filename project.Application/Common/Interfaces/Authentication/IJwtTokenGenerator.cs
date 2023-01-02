using System;
using project.Domain.Entities;

namespace project.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}

