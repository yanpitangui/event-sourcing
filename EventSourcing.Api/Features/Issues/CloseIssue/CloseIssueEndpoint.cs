using EventSourcing.Api.Domain.Issues;
using FastEndpoints;
using Marten;

namespace EventSourcing.Api.Features.Issues.CloseIssue;

public sealed class CloseIssueEndpoint : Endpoint<CloseIssue>
{
    private readonly IDocumentSession _documentSession;
    public CloseIssueEndpoint(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }
    
    public override void Configure()
    {
        Put("{issueId}/close");
        AllowAnonymous();
        Group<IssueGroup>();

    }
    
    public override async Task HandleAsync(CloseIssue req, CancellationToken ct)
    {
        
        _documentSession.Events.Append(req.IssueId, new IssueClosed(req.UserId, DateTimeOffset.Now));

        await _documentSession.SaveChangesAsync(ct);
    }
}