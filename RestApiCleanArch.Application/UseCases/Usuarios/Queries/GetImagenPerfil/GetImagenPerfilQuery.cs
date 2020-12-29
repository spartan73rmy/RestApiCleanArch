using RestApiCleanArch.Domain.Enums;
using MediatR;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Queries.GetImagenPerfil
{
    public class GetImagenPerfilQuery : IRequest<GetImagenPerfilResponse>
    {
        public string NombreUsuario { get; set; }
        public MySize Size { get; set; }
    }
}