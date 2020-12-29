using MediatR;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.AgregarImagenPerfil
{
    public class AgregarImagenPerfilCommand : IRequest<AgregarImagenPerfilResponse>
    {
        public string Imagen { get; set; }
    }
}