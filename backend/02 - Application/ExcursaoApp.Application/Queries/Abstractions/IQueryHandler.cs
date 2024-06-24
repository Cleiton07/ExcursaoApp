using MediatR;

namespace ExcursaoApp.Application.Queries.Abstractions;

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}