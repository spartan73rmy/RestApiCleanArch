using RestApiCleanArch.Application.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.Infraestructure
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger logger;
        private readonly IUserAccessor currentUserService;

        public RequestLogger(ILogger<TRequest> logger, IUserAccessor currentUserService)
        {
            this.logger = logger;
            this.currentUserService = currentUserService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            logger.LogInformation("RestApiCleanArch Request: {Name} UserId: {UserId} Request: {@Request}", name, currentUserService.UserId, request);

            return Task.CompletedTask;
        }
    }
}
