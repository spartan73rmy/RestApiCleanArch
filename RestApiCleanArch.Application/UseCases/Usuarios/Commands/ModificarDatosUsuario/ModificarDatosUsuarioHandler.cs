using RestApiCleanArch.Application.Exceptions;
using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.ModificarDatosUsuario
{
    public class ModificarDatosUsuarioHandler : IRequestHandler<ModificarDatosUsuarioCommand, ModificarDatosUsuarioResponse>
    {
        private readonly IRestApiCleanArchDbContext db;

        public ModificarDatosUsuarioHandler(IRestApiCleanArchDbContext db)
        {
            this.db = db;
        }

        public async Task<ModificarDatosUsuarioResponse> Handle(ModificarDatosUsuarioCommand request, CancellationToken cancellationToken)
        {
            Usuario entity = await db.Usuario.FindAsync(request.IdUsuario);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.IdUsuario);
            }

            entity.Nombre = request.Nombre;
            entity.ApellidoPaterno = request.ApellidoPaterno;
            entity.ApellidoMaterno = request.ApellidoMaterno;

            await db.SaveChangesAsync(cancellationToken);

            return new ModificarDatosUsuarioResponse
            {
                IdUsuario = entity.Id,
                Nombre = entity.Nombre,
                ApellidoPaterno = entity.ApellidoPaterno,
                ApellidoMaterno = entity.ApellidoMaterno
            };
        }
    }
}