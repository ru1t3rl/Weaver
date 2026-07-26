using Cortex.Mediator.Queries;
using Microsoft.EntityFrameworkCore;
using Weaver.Commands.Models;
using Weaver.Domain.Entities;
using Weaver.Infrastructure;

namespace Weaver.Commands.ComposeProjectCommands;

public class GetProjectByUuidQueryHandler : IQueryHandler<GetProjectByUuidQuery, QueryResult<ComposeProject>>
{
    private readonly WeaverDbContext _dbContext;

    public GetProjectByUuidQueryHandler(WeaverDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<QueryResult<ComposeProject>> Handle(
        GetProjectByUuidQuery query,
        CancellationToken cancellationToken
    )
    {
        ComposeProject? project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.Uuid == query.Uuid);
        return project is not null
            ? QueryResult.Success(project)
            : QueryResult.NotFound<ComposeProject>(query.Uuid);
    }
}