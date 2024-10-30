using Application.Features.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Users.Commands;

public record RegisterAccountCommand(RegisterDTO RegisterDto) : IRequest<IdentityResult>;