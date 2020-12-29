using FitoReport.Application.Exceptions;
using FitoReport.Application.Interfaces;
using FitoReport.Application.Security;
using FitoReport.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Usuarios.Commands.RecuperaPassword
{
    public class RecuperaPasswordHandler : IRequestHandler<RecuperaPasswordCommand, RecuperaPasswordResponse>
    {
        private readonly IFitoReportDbContext db;

        public RecuperaPasswordHandler(IFitoReportDbContext db)
        {
            this.db = db;
        }

        public async Task<RecuperaPasswordResponse> Handle(RecuperaPasswordCommand request, CancellationToken cancellationToken)
        {
            var usuario = await db
                .Usuario
                .SingleOrDefaultAsync(el => el.TokenConfirmacion == request.Token);

            if (usuario == null) throw new NotFoundException(nameof(Usuario), new { });

            string pass = PasswordStorage.CreateHash(request.Password);

            usuario.HashedPassword = pass;
            usuario.TokenConfirmacion = null;

            await db.SaveChangesAsync(cancellationToken);

            return new RecuperaPasswordResponse();
        }
    }
}