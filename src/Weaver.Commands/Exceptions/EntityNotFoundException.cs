namespace Weaver.Commands.Exceptions;

public class EntityNotFoundException : Exception
{
    public string EntityName { get; }
    public object EntityId { get; }

    public EntityNotFoundException(string entityName, object entityId)
        : base($"{entityName} with id '{entityId}' was not found.")
    {
        EntityName = entityName;
        EntityId = entityId;
    }

    public EntityNotFoundException(string entityName, object entityId, Exception innerException)
        : base($"{entityName} with id '{entityId}' was not found.", innerException)
    {
        EntityName = entityName;
        EntityId = entityId;
    }
}