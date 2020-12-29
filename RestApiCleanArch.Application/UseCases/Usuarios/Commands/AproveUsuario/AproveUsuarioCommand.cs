using MediatR;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.AproveUsuario
{
    public class AproveUsuarioCommand : IRequest<AproveUsuarioResponse>
    {
        public string NombreUsuario { get; set; }
    }
}
