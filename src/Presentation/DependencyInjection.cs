using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddFastEndpoints();
        
        return services;
    }
}