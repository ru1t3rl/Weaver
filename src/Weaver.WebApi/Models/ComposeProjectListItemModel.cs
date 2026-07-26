namespace Weaver.WebApi.Models;

public record ComposeProjectListItemModel(
    Guid Id,
    string Name,
    string? Description,
    List<string> Tags
);