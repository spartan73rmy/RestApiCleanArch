using MediatR;

namespace FitoReport.Application.UseCases.Usuarios.Commands.AgregarImagenPerfil
{
    public class AgregarImagenPerfilCommand : IRequest<AgregarImagenPerfilResponse>
    {
        public string Imagen { get; set; }
    }
}