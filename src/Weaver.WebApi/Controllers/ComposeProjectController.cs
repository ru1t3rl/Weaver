using Cortex.Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Weaver.Commands.ComposeProjectCommands;
using Weaver.Domain.Entities;
using Weaver.Infrastructure;
using Weaver.WebApi.Models;

namespace Weaver.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class ComposeProjectController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly WeaverDbContext _dbContext;

    public ComposeProjectController(IMediator mediator, WeaverDbContext dbContext)
    {
        _mediator = mediator;
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ComposeProjectListItemModel>>> Get(CancellationToken cancellationToken)
    {
        List<ComposeProjectListItemModel> items = await (
            from project in _dbContext.Projects
            select new ComposeProjectListItemModel(
                project.Uuid,
                project.Name,
                project.Description,
                project.Tags.Select(t => t.Name).ToList()
            )
        ).ToListAsync(cancellationToken);
        
        return Ok(items);
    }

    [HttpPut]
    public async Task<ActionResult<ComposeProjectDetailModel>> Create(CreateProjectCommand command, CancellationToken cancellationToken)
    {
        ComposeProject project = await _mediator.SendCommandAsync(command, cancellationToken);
        ComposeProjectDetailModel model = new(
            project.Uuid,
            project.Name,
            project.Description,
            project.Tags.Select(t => t.Name).ToList()
        );

        return Ok(model);
    }
}