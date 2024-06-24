using MediatR;

namespace ExcursaoApp.Application.Queries.Abstractions;

public interface IQuery<TResult> : IRequest<TResult>
{
}