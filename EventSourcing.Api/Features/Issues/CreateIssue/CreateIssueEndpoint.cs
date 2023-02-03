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
        
        var issueId = _documentSession.Events.StartStream<Issue>(new IssueCreated(req.Description, DateTimeOffset.Now)).Id;

        await _documentSession.SaveChangesAsync(ct);

        await SendOkAsync(issueId, ct);
    }
}