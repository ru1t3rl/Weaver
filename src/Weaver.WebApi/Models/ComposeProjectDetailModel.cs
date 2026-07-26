namespace Weaver.WebApi.Models;

public record struct ComposeProjectDetailModel(
    Guid Id,
    string Name,
    string? Description,
    List<string> Tags
);