using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Notifications.Models;
using RestApiCleanArch.Application.Options;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.RecuperaPasswordGeneraToken
{
    public class RecuperaPasswordGeneraTokenNotificate : INotification
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public class Handler : INotificationHandler<RecuperaPasswordGeneraTokenNotificate>
        {
            private readonly IEmailService emailService;
            private readonly AppSettings options;

            public Handler(IEmailService emailService, IOptions<AppSettings> options)
            {
                this.emailService = emailService;
                this.options = options.Value;
            }

            public async Task Handle(RecuperaPasswordGeneraTokenNotificate notification, CancellationToken cancellationToken)
            {
                await emailService.SendAsync(new Email
                {
                    To = notification.Email,
                    Body = $"Si olvido su Contraseña acceda al siguiente link para <a href='{options.AppUrl}/cuenta/recuperar-password?token={notification.Token}'>confirmar</a>, de lo contrario puede ignorar el email.",
                    From = "AppIAS",
                    Subject = "Solicitud de Recuperación de Contraseña",
                    IsBodyHtml = true
                });
            }
        }
    }
}