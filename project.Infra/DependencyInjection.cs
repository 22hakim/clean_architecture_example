using System;
using Microsoft.Extensions.DependencyInjection;
using project.Application.Services.Authentication;

namespace project.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrasctructure(
        this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}

