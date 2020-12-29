using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.Security
{
    public interface IAuthenticatedRequest<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task Validate(TRequest request, ValidationResult validationResult);
    }

    public class ValidationResult
    {
        public IList<string> Errors { get; set; } = new List<string>();
    }
}
