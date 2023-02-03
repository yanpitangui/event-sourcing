namespace EventSourcing.Api.Features.Issues.CloseIssue;

public record CloseIssue
{

    public CloseIssue()
    {
        
    }

    public Guid IssueId { get; init; }
    public Guid UserId { get; init; }
    
}