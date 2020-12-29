using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiCleanArch.Application.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException(IEnumerable<string> failures) : base($"Ocurrieron errores en la autorización.")
        {
            this.Failures = failures.Select(el => el); // Copiar
        }
        public NotAuthorizedException(string failure) : this(new[] { failure })
        {

        }
        public IEnumerable<string> Failures { get; }
    }
}
