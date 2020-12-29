using MediatR;

namespace FitoReport.Application.UseCases.Usuarios.Queries.GetUsuarioDetail
{
    public class GetUsuarioDetailQuery : IRequest<GetUsuarioDetailResponse>
    {
        public int? IdUsuario { get; set; }
    }
}