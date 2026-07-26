using Cortex.Mediator.Queries;
using Weaver.Commands.Models;
using Weaver.Domain.Entities;

namespace Weaver.Commands.ComposeProjectCommands;

public record GetProjectsByTagQuery(List<Tag> Tags) : IQuery<QueryResult<IEnumerable<ComposeProject>>>;