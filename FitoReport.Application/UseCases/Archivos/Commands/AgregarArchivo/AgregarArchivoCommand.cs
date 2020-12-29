using MediatR;
using System.IO;

namespace FitoReport.Application.UseCases.Archivos.Commands.AgregarArchivo
{
    public class AgregarArchivoCommand : IRequest<AgregarArchivoResponse>
    {
        public Stream Archivo { get; set; }
        public string Nombre { get; set; }
        public string ContentType { get; set; }
    }
}