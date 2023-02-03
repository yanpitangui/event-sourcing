namespace EventSourcing.Api.Features.Issues.GetIssue;

public record GetIssue
{
    public Guid IssueId { get; init; }
}