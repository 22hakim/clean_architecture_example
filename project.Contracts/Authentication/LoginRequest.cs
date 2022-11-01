using System;
namespace project.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password
);
