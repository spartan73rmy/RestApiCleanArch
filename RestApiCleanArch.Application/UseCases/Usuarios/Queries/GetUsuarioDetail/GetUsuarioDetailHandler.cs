using RestApiCleanArch.Application.Exceptions;
using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Queries.GetUsuarioDetail
{
    public class GetUsuarioDetailHandler : IRequestHandler<GetUsuarioDetailQuery, GetUsuarioDetailResponse>
    {
        private readonly IRestApiCleanArchDbContext db;

        public GetUsuarioDetailHandler(IRestApiCleanArchDbContext db)
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