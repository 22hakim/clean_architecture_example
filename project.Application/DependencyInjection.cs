using System;
using Microsoft.Extensions.DependencyInjection;
using project.Application.Services.Authentication;

namespace project.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();

        return serviceCollection;
    }
}

