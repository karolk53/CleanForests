using Application.Features.Users.Commands;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Presentation.Endpoints.Users;

public class Login : Endpoint<LoginUserCommand, string>
{
    private readonly IMediator _mediator;
    public Login(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override void Configure()
    {
        Post("/api/login");
        AllowAnonymous();
        Description(opt => opt
            .Accepts<LoginUserCommand>()
            .Produces<string>(200)
            .ProducesProblemFE(401),
        clearDefaults: true);
    }
    
    public override async Task HandleAsync(LoginUserCommand req, CancellationToken ct)
    {
        var result = await _mediator.Send(req, ct);
        if (result.IsFailed)
        {
            AddError(result.Errors.First().Message);
            ThrowIfAnyErrors(statusCode: 401);
        }
        
        await SendOkAsync(result.Value, ct);
    }
}