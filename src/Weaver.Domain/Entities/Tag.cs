using Weaver.Domain.Common;

namespace Weaver.Domain.Entities;

public class Tag : EntityBase
{
    public required string Name { get; set; }
    public static implicit operator string(Tag tag) => tag.Name;
}