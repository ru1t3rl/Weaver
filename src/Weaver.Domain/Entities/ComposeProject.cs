using Weaver.Domain.Common;

namespace Weaver.Domain.Entities;

public class ComposeProject : EntityBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public List<Tag> Tags { get; init; } = [];
}