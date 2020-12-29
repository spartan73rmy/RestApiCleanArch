using MediatR;

namespace FitoReport.Application.UseCases.Archivos.Queries.TokenDescarga
{
    public class TokenDescargaQuery : IRequest<TokenDescargaResponse>
    {
        public string HashArchivo { get; set; }
    }
}