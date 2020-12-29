using MediatR;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Queries.GetUsuarioDetail
{
    public class GetUsuarioDetailQuery : IRequest<GetUsuarioDetailResponse>
    {
        public int? IdUsuario { get; set; }
    }
}