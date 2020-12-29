using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiCleanArch.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("Ocurrieron algunos erroes en las validaciones.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            var propertyNames = failures
                .Select(el => el.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(el => el.PropertyName == propertyName)
                    .Select(el => el.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}
