using MediatR;

namespace RestApiCleanArch.Application.Security
{
    public interface IAdminRequest<TRequest, TResponse> : IAuthenticatedRequest<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
    }
}
