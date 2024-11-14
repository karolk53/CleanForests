using Application.Features.Users.Commands;
using FluentResults;

namespace Application.Abstractions;

public interface ICommandHandler<TCommand>
{
    Task<Result> HandleAsync(RegisterAccountCommand command, CancellationToken cancellationToken);
}