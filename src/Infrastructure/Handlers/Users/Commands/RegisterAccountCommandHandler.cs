using Application.Features.Users.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Handlers.Users.Commands;

public class RegisterAccountCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    : IRequestHandler<RegisterAccountCommand, IdentityResult>
{
    public async Task<IdentityResult> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
    {
        var user = new AppUser
        {
            UserName = request.RegisterDto.UserName,
            Email = request.RegisterDto.Email
        };
        
        var result = await userManager.CreateAsync(user, request.RegisterDto.Password);
        
        return result;
    }
}