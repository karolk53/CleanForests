﻿using Application.Features.Users.Commands;
using FastEndpoints;
using MediatR;

namespace Presentation.Endpoints.Users;

public class Register : Endpoint<RegisterAccountCommand>
{

    private readonly IMediator _mediator;

    public Register(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post("/api/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterAccountCommand req, CancellationToken ct)
    {
        var result = await _mediator.Send(req, ct);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                AddError(error.Description);
            }
            ThrowIfAnyErrors();
        }
        
        await SendOkAsync(ct);
    }
}