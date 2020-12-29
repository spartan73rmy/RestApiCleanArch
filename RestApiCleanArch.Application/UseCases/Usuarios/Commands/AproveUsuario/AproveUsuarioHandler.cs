using RestApiCleanArch.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.AproveUsuario
{
    public class AproveUsuarioHandler : IRequestHandler<AproveUsuarioCommand, AproveUsuarioResponse>
    {
        private readonly IRestApiCleanArchDbContext db;

        public AproveUsuarioHandler(IRestApiCleanArchDbContext db)
        {
            this.db = db;
        }

        public async Task<AproveUsuarioResponse> Handle(AproveUsuarioCommand request, CancellationToken cancellationToken)
        {
            var user = await db
                        .Usuario
                        .SingleOrDefaultAsync(el => el.NombreUsuario == request.NombreUsuario || el.Email == request.NombreUsuario);
            if (user != null)
            {
                db.Usuario.Attach(user);
                user.Confirmado = true;
                await db.SaveChangesAsync(cancellationToken);
            }
            return new AproveUsuarioResponse();
        }
    }
}
