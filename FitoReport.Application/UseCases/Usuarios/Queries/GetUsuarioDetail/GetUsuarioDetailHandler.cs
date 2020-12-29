using FitoReport.Application.Exceptions;
using FitoReport.Application.Interfaces;
using FitoReport.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Usuarios.Queries.GetUsuarioDetail
{
    public class GetUsuarioDetailHandler : IRequestHandler<GetUsuarioDetailQuery, GetUsuarioDetailResponse>
    {
        private readonly IFitoReportDbContext db;

        public GetUsuarioDetailHandler(IFitoReportDbContext db)
        {
            this.db = db;
        }

        public async Task<GetUsuarioDetailResponse> Handle(GetUsuarioDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.Usuario.FindAsync(request.IdUsuario);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.IdUsuario);
            }

            return new GetUsuarioDetailResponse
            {
                Email = entity.Email,
                TipoUsuario = entity.TipoUsuario,
                IdUsuario = entity.Id,
                NombreUsuario = entity.NombreUsuario,
                Nombre = entity.Nombre,
                ApellidoPaterno = entity.ApellidoPaterno,
                ApellidoMaterno = entity.ApellidoMaterno
            };
        }
    }
}