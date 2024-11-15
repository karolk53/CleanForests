using Application.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories;

public class UserRepository(UserManager<AppUser> userManager) : IUserRepository 
{
    public async Task<bool> UserExists(string emial)
    {
        return userManager.Users.Any(u => u.Email == emial);
    }
}