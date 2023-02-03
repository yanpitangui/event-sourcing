using FastEndpoints;
using Marten;

namespace EventSourcing.Api.Features.Issues.GetIssue;

public sealed class GetIssueEndpoint : Endpoint<GetIssue>
{

    private readonly IDocumentSession _session;
    public GetIssueEndpoint(IDocumentSession session)
    {
        _session = session;
    }
    public override void Configure()
    {
        Get("{issueId}");
        AllowAnonymous();
        Group<IssueGroup>();

    }
    
    public override async Task HandleAsync(GetIssue req, CancellationToken ct)
    {
        var events = await _session.Events.FetchStreamAsync(req.IssueId, token: ct);
        await SendOkAsync(events.Select(x => new { x.Data, Name = x.EventTypeName }).ToArray(), ct);
    }
}