using System.IO;

namespace FitoReport.Application.UseCases.Archivos.Queries.DescargarArchivo
{
    public class DescargarArchivoResponse
    {
        public Stream Archivo { get; set; }
        public string ContentType { get; set; }
        public string Nombre { get; set; }
    }
}