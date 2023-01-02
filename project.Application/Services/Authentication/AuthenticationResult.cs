using System;
using project.Domain.Entities;

namespace project.Application.Services.Authentication;

public record AuthenticationResult
(
    User user,
    string Token
);

