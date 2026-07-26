namespace Weaver.Commands.Exceptions;

public class EntityNotFoundException<TEntity> : EntityNotFoundException
{
    public EntityNotFoundException(object entityId)
        : base(typeof(TEntity).Name, entityId)
    {
    }
}