using MediatR;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioCommand : IRequest<DeleteUsuarioResponse>
    {
        public string NombreUsuario { get; set; }
    }
}
