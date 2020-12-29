using RestApiCleanArch.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioCommand, DeleteUsuarioResponse>
    {
        private readonly IRestApiCleanArchDbContext db;

        public DeleteUsuarioHandler(IRestApiCleanArchDbContext db)
        {
            this.db = db;
        }

        public async Task<DeleteUsuarioResponse> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            var user = await db
                        .Usuario
                        .SingleOrDefaultAsync(el => el.NombreUsuario == request.NombreUsuario || el.Email == request.NombreUsuario);
            if (user != null)
            {
                var archivos = await db.ArchivoUsuario.Where(el => el.IdUsuario == user.Id).ToListAsync();
                var tokens = await db.UsuarioToken.Where(el => el.IdUsuario == user.Id).ToListAsync();
                db.ArchivoUsuario.RemoveRange(archivos); //TODO delete files from server
                db.UsuarioToken.RemoveRange(tokens);
                db.Usuario.Remove(user);
                await db.SaveChangesAsync(cancellationToken);
            }

            return new DeleteUsuarioResponse();
        }
    }
}
