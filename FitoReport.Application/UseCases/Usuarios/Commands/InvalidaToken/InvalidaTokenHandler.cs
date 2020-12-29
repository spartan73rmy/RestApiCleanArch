using FitoReport.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Usuarios.Commands.InvalidaToken
{
    public class InvalidaTokenHandler : IRequestHandler<InvalidaTokenCommand, InvalidaTokenResponse>
    {
        private readonly IFitoReportDbContext db;

        public InvalidaTokenHandler(IFitoReportDbContext db)
        {
            this.db = db;
        }

        public async Task<InvalidaTokenResponse> Handle(InvalidaTokenCommand request, CancellationToken cancellationToken)
        {
            var token = await db.UsuarioToken.SingleOrDefaultAsync(el => el.RefreshToken == request.RefreshToken);
            if (token != null)
            {
                db.UsuarioToken.Remove(token);
                await db.SaveChangesAsync(cancellationToken);
            }
            return new InvalidaTokenResponse { };
        }
    }
}