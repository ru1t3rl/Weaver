using Cortex.Mediator.Queries;
using Microsoft.EntityFrameworkCore;
using Weaver.Commands.Models;
using Weaver.Domain.Entities;
using Weaver.Infrastructure;

namespace Weaver.Commands.ComposeProjectCommands;

public class
    GetProjectsByTagsQueryHandler : IQueryHandler<GetProjectsByTagQuery, QueryResult<IEnumerable<ComposeProject>>>
{
    private readonly WeaverDbContext _dbContext;

    public GetProjectsByTagsQueryHandler(WeaverDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<QueryResult<IEnumerable<ComposeProject>>> Handle(
        GetProjectsByTagQuery query,
        CancellationToken cancellationToken
    )
    {
        IEnumerable<ComposeProject> projects = await (
            from project in _dbContext.Projects
            let tags = project.Tags
            where project.Tags.Any(tags.Contains)
            select project
        ).ToListAsync(cancellationToken);

        return QueryResult.Success(projects);
    }
}