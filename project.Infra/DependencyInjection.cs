using System;
using Microsoft.Extensions.DependencyInjection;
using project.Application.Common.Interfaces.Authentication;
using project.Application.Services.Authentication;
using project.Infra.Authentication;

namespace project.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrasctructure(
        this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return serviceCollection;
    }
}

