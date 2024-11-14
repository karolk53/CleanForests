using Application.Features.Users.Commands;
using Application.Repositories;
using Application.Services.Abstractions;
using Domain.Entities;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Handlers.Users.Commands;

public class RegisterAccountCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, 
    ITokenService tokenService, IUserRepository userRepository)
    : IRequestHandler<RegisterAccountCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.UserExists(request.RegisterDto.UserName))
        {
            return Result.Fail($"User with name {request.RegisterDto.UserName} already exists.");
        }
        
        var user = new AppUser
        {
            UserName = request.RegisterDto.UserName,
            Email = request.RegisterDto.Email
        };
        
        var result = await userManager.CreateAsync(user, request.RegisterDto.Password);

        if (!result.Succeeded)
        {
            return Result.Fail(result.Errors.Select(e => e.Description).ToList());
        }

        return Result.Ok(await tokenService.CreateToken(user));
    }
}