using RestApiCleanArch.Application.Exceptions;
using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.RefreshCredentials
{
    public class RefreshCredentialsHandler : IRequestHandler<RefreshCredentialsCommand, RefreshCredentialsResponse>
    {
        private readonly IRestApiCleanArchDbContext db;
        private readonly IRandomGenerator randomGenerator;

        public RefreshCredentialsHandler(IRestApiCleanArchDbContext db, IRandomGenerator randomGenerator)
        {
            this.db = db;
            this.randomGenerator = randomGenerator;
        }

        public async Task<RefreshCredentialsResponse> Handle(RefreshCredentialsCommand request, CancellationToken cancellationToken)
        {
            var token = await db
                .UsuarioToken
                .Include(el => el.UsuarioNavigation)
                .SingleOrDefaultAsync(el => el.RefreshToken == request.RefreshToken);

            if (token == null)
            {
                throw new NotAuthorizedException("No se puede comprobar tu informacion");
            }

            string randomToken = randomGenerator.SecureRandomString(32);
            token.RefreshToken = randomToken;
            await db.SaveChangesAsync(cancellationToken);

            return new RefreshCredentialsResponse
            {
                Email = token.UsuarioNavigation.Email,
                IdUsuario = token.IdUsuario,
                NombreUsuario = token.UsuarioNavigation.NombreUsuario,
                RefreshToken = token.RefreshToken,
                TipoUsuario = token.UsuarioNavigation.TipoUsuario
            };
        }
    }
}