using Application.Features.Users.Commands;
using Application.Repositories;
using Application.Services.Abstractions;
using Domain.Entities;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Handlers.Users.Commands;

public class LoginUserCommandHandler(IUserRepository userRepository, ITokenService tokenService, UserManager<AppUser> userManager) : IRequestHandler<LoginUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.Users.SingleOrDefaultAsync(x => x.Email.Equals(request.LoginDto.Email), cancellationToken);
        if (user == null)
        {
            return Result.Fail("Invalid email or password");
        }
        
        var result = await userManager.CheckPasswordAsync(user, request.LoginDto.Password);
        if (!result)
        {
            return Result.Fail("Invalid email or password");
        }

        return Result.Ok(await tokenService.CreateToken(user));
    }
}