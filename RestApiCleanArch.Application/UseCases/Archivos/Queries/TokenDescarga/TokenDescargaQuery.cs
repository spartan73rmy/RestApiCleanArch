using MediatR;

namespace RestApiCleanArch.Application.UseCases.Archivos.Queries.TokenDescarga
{
    public class TokenDescargaQuery : IRequest<TokenDescargaResponse>
    {
        public string HashArchivo { get; set; }
    }
}