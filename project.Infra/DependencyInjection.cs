using System;
using Microsoft.Extensions.DependencyInjection;
using project.Application.Common.Interfaces.Authentication;
using project.Application.Common.Interfaces.Services;
using project.Infra.Services;
using project.Application.Services.Authentication;
using project.Infra.Authentication;
using Microsoft.Extensions.Configuration;
using project.Application.Common.Interfaces.Persistance;
using project.Infra.Persistence;

namespace project.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrasctructure(
        this IServiceCollection serviceCollection,
        ConfigurationManager configuration)
    {
        serviceCollection.Configure<JwtConfig>(configuration.GetSection(JwtConfig.SectionName));
        serviceCollection.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        serviceCollection.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        return serviceCollection;
    }
}

