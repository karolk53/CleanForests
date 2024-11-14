using Application.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories;

public class UserRepository(UserManager<AppUser> userManager) : IUserRepository 
{
    public async Task<bool> UserExists(string username)
    {
        return userManager.Users.Any(u => u.UserName == username);
    }
}