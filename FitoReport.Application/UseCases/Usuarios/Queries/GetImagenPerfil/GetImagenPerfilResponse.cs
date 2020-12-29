using System.IO;

namespace FitoReport.Application.UseCases.Usuarios.Queries.GetImagenPerfil
{
    public class GetImagenPerfilResponse
    {
        public Stream Imagen { get; set; }
        public string ContentType { get; set; }
    }
}