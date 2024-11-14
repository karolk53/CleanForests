using Application.Features.Users.DTOs;
using FluentResults;
using MediatR;

namespace Application.Features.Users.Commands;

public record RegisterAccountCommand(RegisterDTO RegisterDto) : IRequest<Result<string>>;