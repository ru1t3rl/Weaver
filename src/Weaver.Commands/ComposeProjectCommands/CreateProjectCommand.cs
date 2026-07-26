using Cortex.Mediator.Commands;
using OneOf;
using OneOf.Types;
using Weaver.Domain.Entities;

namespace Weaver.Commands.ComposeProjectCommands;

public record CreateProjectCommand(
    string Name,
    string? Description = null,
    List<Tag>? Tags = null
) : ICommand<ComposeProject>;