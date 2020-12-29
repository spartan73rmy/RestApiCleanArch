using MediatR;

namespace RestApiCleanArch.Application.Security
{
    interface IUserRequest<TRequest, TResponse> : IAuthenticatedRequest<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

    }
}
