using FitoReport.Application.Interfaces;
using FitoReport.Application.Notifications.Models;
using FitoReport.Application.Options;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Usuarios.Commands.ReenviarEmail
{
    public class ReenviarEmailNotificate : INotification
    {
        public string Email { get; set; }

        public class ReenviarEmailHandler : INotificationHandler<ReenviarEmailNotificate>
        {
            private readonly IEmailService emailService;
            private readonly IFitoReportDbContext db;
            private readonly AppSettings settings;

            public ReenviarEmailHandler(IEmailService emailService, IFitoReportDbContext db, IOptions<AppSettings> options)
            {
                this.emailService = emailService;
                this.db = db;
                this.settings = options.Value;
            }

            public async Task Handle(ReenviarEmailNotificate notification, CancellationToken cancellationToken)
            {
                var usuario = await db
               .Usuario
               .Select(el => new ReenviarEmailResponse
               {
                   Email = el.Email,
                   Confirmado = el.Confirmado,
                   TipoUsuario = el.TipoUsuario,
                   Token = el.TokenConfirmacion
               })
               .SingleOrDefaultAsync(el => el.Email == notification.Email, cancellationToken);

                await emailService.SendAsync(new Email
                {
                    To = usuario.Email,
                    Body = $"Su usuario ha sido registrado, acceda al siguiente link para <a href='{settings.AppUrl}/cuenta/confirmar?token={usuario.Token}'>confirmar</a>, de lo contrario puede ignorar el email.",
                    From = "AppIAS",
                    Subject = "Registro Completo",
                    IsBodyHtml = true
                });
            }
        }
    }
}