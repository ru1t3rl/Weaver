using OneOf.Types;
using Weaver.Commands.Exceptions;

namespace Weaver.Commands.Models;

public abstract record QueryResult<T>
{
    public sealed record Success(T Value) : QueryResult<T>;
    public sealed record NotFound(object Id) : QueryResult<T>;
    public sealed record Failure(Exception Exception) : QueryResult<T>;

    public TResult Match<TResult>(
        Func<T, TResult> onSuccess,
        Func<EntityNotFoundException, TResult> onNotFound,
        Func<Exception, TResult> onFailure) => this switch
    {
        Success s => onSuccess(s.Value),
        NotFound n => onNotFound(new EntityNotFoundException<T>(n.Id)),
        Failure f => onFailure(f.Exception),
        _ => throw new InvalidOperationException()
    };
}

public abstract record QueryResult
{
    public static QueryResult<TResult>.Success Success<TResult>(TResult @object)
    {
        return new QueryResult<TResult>.Success(@object);
    }

    public static QueryResult<TResult>.NotFound NotFound<TResult>(object id)
    {
        return new QueryResult<TResult>.NotFound(id);
    }
    
    public static QueryResult<TResult>.Failure Failure<TResult>(Exception exception)
    {
        return new QueryResult<TResult>.Failure(exception);
    }
}