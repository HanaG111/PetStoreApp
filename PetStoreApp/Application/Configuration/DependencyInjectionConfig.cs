using PetStoreApp.Domain.Interfaces;
using PetStoreApp.Domain.Services;
using PetStoreApp.Infrastructure.Context;
using PetStoreApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace PetStoreApp.Application.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<PetStoreDbContext>();

        services.AddScoped<IPetRepository, PetRepository>();
        services.AddScoped<IPetRepository, PetRepository>();

        services.AddScoped<IPetService, PetService>();

        return services;
    }
}