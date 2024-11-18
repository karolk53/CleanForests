using Application.Repositories;
using Application.Services.Abstractions;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(assembly));
        
        services.AddDbContext<DataContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddIdentityCore<AppUser>(opt => 
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<AppRole>()
            .AddRoleManager<RoleManager<AppRole>>()
            .AddEntityFrameworkStores<DataContext>();

        services.AddAuthorization(opt => 
        {
            opt.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
        });
        
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}