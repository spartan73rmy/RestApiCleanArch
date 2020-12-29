using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = RestApiCleanArch.Application.Exceptions.ValidationException;

namespace RestApiCleanArch.Application.Infraestructure
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<RequestValidationBehavior<TRequest, TResponse>> logger;
        private readonly Stopwatch timer;
        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<RequestValidationBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            this.logger = logger;
            this.timer = new Stopwatch();

        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            timer.Start();

            var context = new ValidationContext(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
            var failuresAsync = (await Task.WhenAll(_validators
                .Select(async v => await v.ValidateAsync(context))))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failuresAsync.Count != 0)
            {
                throw new ValidationException(failuresAsync);
            }

            timer.Stop();
            logger.LogInformation("Validation behaviour took {ElapsedMilliseconds}ms", timer.ElapsedMilliseconds);

            return await next();
        }
    }
}
