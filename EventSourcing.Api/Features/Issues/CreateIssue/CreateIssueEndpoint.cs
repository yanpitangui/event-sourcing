using EventSourcing.Api.Domain.Issues;
using FastEndpoints;
using Marten;

namespace EventSourcing.Api.Features.Issues.CreateIssue;

public class CreateIssueEndpoint : Endpoint<CreateIssue>
{
    private readonly IDocumentSession _documentSession;
    public CreateIssueEndpoint(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }
    public override void Configure()
    {
        Post("");
        AllowAnonymous();
        Group<IssueGroup>();

    }

    public override async Task HandleAsync(CreateIssue req, CancellationToken ct)
    {
        var issue = new Issue();
        
        _documentSession.Store(issue);
        _documentSession.Events.Append(issue.Id, new IssueCreated(req.Description, DateTimeOffset.Now));

        await _documentSession.SaveChangesAsync(ct);

        await SendOkAsync(issue.Id, ct);
    }
}