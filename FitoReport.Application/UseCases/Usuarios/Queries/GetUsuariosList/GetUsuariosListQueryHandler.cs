using FitoReport.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Usuarios.Queries.GetUsuariosList
{
    public class GetUsuariosListQueryHandler : IRequestHandler<GetUsuariosListQuery, GetUsuariosListResponse>
    {
        private readonly IFitoReportDbContext db;

        public GetUsuariosListQueryHandler(IFitoReportDbContext db)
        {
            this.db = db;
        }

        public async Task<GetUsuariosListResponse> Handle(GetUsuariosListQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await db
                .Usuario
                .Select(el => new UsuarioLookupModel
                {
                    Id = el.Id,
                    NombreUsuario = el.NombreUsuario,
                    Email = el.Email,
                    Nombre = el.Nombre,
                    ApellidoPaterno = el.ApellidoPaterno,
                    ApellidoMaterno = el.ApellidoMaterno,
                    TipoUsuario = el.TipoUsuario,
                    Confirmado = el.Confirmado,
                })
                .OrderBy(el => el.Confirmado)
                .ToListAsync(cancellationToken);

            return new GetUsuariosListResponse { Usuarios = usuarios };
        }
    }
}