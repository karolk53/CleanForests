using System.Text.Json;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public static class Seed
{
    public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        if(await userManager.Users.AnyAsync()) return;

        var users = new[]
        {
            new AppUser
            {
                UserName = "jan",
                Email = "jan@gmail.com",
            },
            new AppUser
            {
                UserName = "ola",
                Email = "ola@gmail.com",
            },
        };
        
        var roles = new List<AppRole>
        {
            new AppRole{Name = "Member"},
            new AppRole{Name = "Admin"},
            new AppRole{Name = "Moderator"}
        };

        foreach(var role in roles)
        {
            await roleManager.CreateAsync(role);
        }

        foreach(var user in users)
        {
            user.UserName = user.UserName.ToLower();
            await userManager.CreateAsync(user, "Pa$$w0rd");
            await userManager.AddToRoleAsync(user, "Member");
        }
    }
}