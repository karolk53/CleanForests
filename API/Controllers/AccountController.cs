using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController : BaseApiController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ITokenService tokenService ,IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> RegisterNewUser(UserRegisterDto registerDto)
    {
        if (await UserExists(registerDto.UserName))
        {
            return BadRequest("User with that username already exists");
        }

        if (await EmailExists(registerDto.Email))
        {
            return BadRequest("Email is already taken");
        }
        
        var user = _mapper.Map<AppUser>(registerDto);
        user.UserName = registerDto.UserName.ToLower();

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded)
        {
            return BadRequest("Failed to register new user");
        }
        
        var roleResult = await _userManager.AddToRoleAsync(user, "Member");
        if (!roleResult.Succeeded)
        {
            return BadRequest("Failed to register new user");
        }

        return new UserDto
        {
            Username = user.UserName,
            Email = user.Email,
            Token = await _tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> LoginUser(UserLoginDto loginDto)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName.Equals(loginDto.UserName));

        if (user == null)
        {
            return BadRequest("Invalid username or password");
        }

        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

        if (!result)
        {
            return BadRequest("Invalid username or password");
        }

        return new UserDto
        {
            Username = user.UserName,
            Email = user.Email,
            Token = await _tokenService.CreateToken(user)
        };
    }

    private async Task<bool> UserExists(string username)
    {
        return await _userManager.Users.AnyAsync(x => x.UserName.Equals(username));
    }
    
    private async Task<bool> EmailExists(string registerDtoEmail)
    {
        return await _userManager.Users.AnyAsync(x => x.Email.Equals(registerDtoEmail));
    }
    
}