using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Archivos.Queries.TokenDescarga
{
    public class TokenDescargaAuth : IAuthenticatedRequest<TokenDescargaQuery, TokenDescargaResponse>
    {
        public TokenDescargaAuth() { }

        public Task Validate(TokenDescargaQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}