using RestApiCleanArch.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.ReenviarEmail
{
    public class ReenviarEmailHandler : IRequestHandler<ReenviarEmailCommand, ReenviarEmailResponse>
    {
        private readonly IMediator mediator;
        private readonly IRestApiCleanArchDbContext db;

        public ReenviarEmailHandler(IMediator mediator, IRestApiCleanArchDbContext db)
        {
            this.mediator = mediator;
            this.db = db;
        }

        public async Task<ReenviarEmailResponse> Handle(ReenviarEmailCommand request, CancellationToken cancellationToken)
        {
            var usuario = await db
               .Usuario
               .Select(el => new ReenviarEmailResponse
               {
                   Email = el.Email,
                   Confirmado = el.Confirmado,
                   TipoUsuario = el.TipoUsuario
               })
               .SingleOrDefaultAsync(el => el.Email == request.Email, cancellationToken);

            //if (usuario.TipoUsuario == Domain.Enums.TiposUsuario.Alumno && usuario.Confirmado == false)
            //    await mediator.Publish(new ReenviarEmailNotificate { Email = request.Email }, cancellationToken);

            return new ReenviarEmailResponse
            {
                Email = request.Email,
                NotificationMessage = "Email Reenviado"
            };
        }
    }
}