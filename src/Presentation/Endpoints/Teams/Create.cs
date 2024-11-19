using FastEndpoints;

namespace Presentation.Endpoints.Teams;

public class Create : Endpoint<string, string>
{
    public override void Configure()
    {
        Post("/api/teams");
    }

    public override Task HandleAsync(string req, CancellationToken ct)
    {
        return base.HandleAsync(req, ct);
    }
}