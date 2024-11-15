using Application.Features.Users.DTOs;
using FluentResults;
using MediatR;

namespace Application.Features.Users.Commands;

public record LoginUserCommand(LoginDTO LoginDto) : IRequest<Result<string>>;