using FastEndpoints;

namespace EventSourcing.Api.Features.Test;

public class TestEndpoint : Endpoint<TestRequest>
{
    public override void Configure()
    {
        Get("test");
        AllowAnonymous();

    }

    public override async Task HandleAsync(TestRequest req, CancellationToken ct)
    {
        await SendOkAsync(req, ct);
    }
}