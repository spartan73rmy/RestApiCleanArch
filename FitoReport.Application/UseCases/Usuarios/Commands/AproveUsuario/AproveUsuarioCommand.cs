using MediatR;

namespace FitoReport.Application.UseCases.Usuarios.Commands.AproveUsuario
{
    public class AproveUsuarioCommand : IRequest<AproveUsuarioResponse>
    {
        public string NombreUsuario { get; set; }
    }
}
