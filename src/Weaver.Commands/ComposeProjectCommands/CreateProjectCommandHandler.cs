using Cortex.Mediator.Commands;
using OneOf;
using OneOf.Types;
using Weaver.Domain.Entities;
using Weaver.Infrastructure;

namespace Weaver.Commands.ComposeProjectCommands;

public class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand, ComposeProject>
{
    private readonly WeaverDbContext _dbContext;

    public CreateProjectCommandHandler(WeaverDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ComposeProject> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
    {
        ComposeProject project = new ()
        {
            Name = command.Name,
            Description = command.Description,
            Tags = command.Tags ?? []
        };

        var entity = await _dbContext.Projects.AddAsync(project, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return entity.Entity;
    }
}