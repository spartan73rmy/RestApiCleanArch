using RestApiCleanArch.Application.Exceptions;
using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Security;
using RestApiCleanArch.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.ModificarPassword
{
    public class ModificarPasswordHandler : IRequestHandler<ModificarPasswordCommand, ModificarPasswordResponse>
    {
        private readonly IRestApiCleanArchDbContext db;
        private readonly IUserAccessor currentUser;

        public ModificarPasswordHandler(IRestApiCleanArchDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task<ModificarPasswordResponse> Handle(ModificarPasswordCommand request, CancellationToken cancellationToken)
        {
            var entity = await db
                .Usuario
                .SingleOrDefaultAsync(el => el.Id == currentUser.UserId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), currentUser.UserId);
            }

            if (PasswordStorage.VerifyPassword(request.PasswordActual, entity.HashedPassword))
            {
                string pass = PasswordStorage.CreateHash(request.PasswordNuevo);

                entity.HashedPassword = pass;

                var tokens = await db
                    .UsuarioToken
                    .Where(el => el.IdUsuario == currentUser.UserId).
                    ToListAsync();

                db.UsuarioToken.RemoveRange(tokens);

                await db.SaveChangesAsync(cancellationToken);

                return new ModificarPasswordResponse
                {
                    Email = entity.Email
                };
            }
            else
            {
                throw new BadRequestException("La contrase�a es Incorrecta");
            }
        }
    }
}