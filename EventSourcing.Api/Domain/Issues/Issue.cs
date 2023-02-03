namespace EventSourcing.Api.Domain.Issues;

public class Issue
{
    public Guid Id { get; set; }
    public string Description { get; private set; }
    
    public DateTimeOffset Created { get; private set; }
    
    public DateTimeOffset? Closed { get; private set; }
    
    public IssueStatus Status { get; set; }

    public void Apply(IssueCreated created)
    {
        Description = created.Description;
        Created = created.Date;
        Status = IssueStatus.Open;
    }

    public void Apply(IssueClosed closed)
    {
        Closed = closed.Date;
        Status = IssueStatus.Closed;
    }
}

public enum IssueStatus
{
    Open,
    Closed
}


public record IssueCreated(string Description, DateTimeOffset Date) : IIssueEvent;
public record IssueClosed(Guid UserId, DateTimeOffset Date) : IIssueEvent;


internal interface IIssueEvent
{
    public DateTimeOffset Date { get; }
}