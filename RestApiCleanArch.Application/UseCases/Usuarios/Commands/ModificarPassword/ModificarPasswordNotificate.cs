using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Notifications.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.ModificarPassword
{
    public class ModificarPasswordNotificate : INotification
    {
        public string Email { get; set; }

        public class ReenviarEmailHandler : INotificationHandler<ModificarPasswordNotificate>
        {
            private readonly IEmailService emailService;
            private readonly IRestApiCleanArchDbContext db;

            public ReenviarEmailHandler(IEmailService emailService, IRestApiCleanArchDbContext db)
            {
                this.emailService = emailService;
                this.db = db;
            }

            public async Task Handle(ModificarPasswordNotificate notification, CancellationToken cancellationToken)
            {
                var usuario = await db
               .Usuario
               .Select(el => new ModificarPasswordResponse
               {
                   Email = el.Email
               })
               .SingleOrDefaultAsync(el => el.Email == notification.Email, cancellationToken);

                await emailService.SendAsync(new Email
                {
                    To = usuario.Email,
                    Body = $"Se ha modificado la contraseña",
                    From = "AppIAS",
                    Subject = "Modificacion Exitosa"
                });
            }
        }
    }
}