using MediatR;

namespace FitoReport.Application.UseCases.Archivos.Queries.DescargarArchivo
{
    public class DescargarArchivoQuery : IRequest<DescargarArchivoResponse>
    {
        public string Hash { get; set; }
        public string TokenDescarga { get; set; }
    }
}