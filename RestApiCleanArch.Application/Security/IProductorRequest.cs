using MediatR;

namespace RestApiCleanArch.Application.Security
{
    interface IProductorRequest<TRequest, TResponse> : IAuthenticatedRequest<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
    }
}
