using Cortex.Mediator.Queries;
using OneOf;
using OneOf.Types;
using Weaver.Commands.Models;
using Weaver.Common.Exceptions;
using Weaver.Domain.Entities;

namespace Weaver.Commands.ComposeProjectCommands;

public record GetProjectByUuidQuery(Guid Uuid) : IQuery<QueryResult<ComposeProject>>;