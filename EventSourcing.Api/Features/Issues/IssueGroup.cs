using FastEndpoints;

namespace EventSourcing.Api.Features.Issues;

public class IssueGroup : Group
{
    public IssueGroup()
    {
        Configure("issue", ep =>
        {
            ep.Description(x => x
                .Produces(401)
                .WithTags("issues"));
        });
    }
}