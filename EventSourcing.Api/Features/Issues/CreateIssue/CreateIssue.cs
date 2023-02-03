namespace EventSourcing.Api.Features.Issues.CreateIssue;

public record CreateIssue
{
    public string Description { get; set; } = null!;
}