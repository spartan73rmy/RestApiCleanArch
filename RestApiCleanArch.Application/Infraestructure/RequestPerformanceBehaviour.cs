using RestApiCleanArch.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.Infraestructure
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch timer;
        private readonly ILogger<TRequest> logger;
        private readonly IUserAccessor currentUser;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger, IUserAccessor currentUser)
        {
            timer = new Stopwatch();

            this.logger = logger;
            this.currentUser = currentUser;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            timer.Start();
            try
            {
                var response = await next();
                timer.Stop();
                return response;
            }
            finally
            {
                if (timer.ElapsedMilliseconds > 500)
                {
                    var name = typeof(TRequest).Name;
                    logger.LogWarning("RestApiCleanArch Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}", name, timer.ElapsedMilliseconds, currentUser.UserId, request);
                }
                else
                {
                    logger.LogInformation("Whole request took {ElapsedMilliseconds}ms", timer.ElapsedMilliseconds);
                }
            }

        }
    }
}
