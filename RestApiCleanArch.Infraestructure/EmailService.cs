using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Notifications.Models;
using RestApiCleanArch.Infraestructure.Options;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RestApiCleanArch.Infraestructure
{
    public class EmailService : IEmailService
    {
        private readonly EmailServiceOptions options;
        public EmailService(IOptions<EmailServiceOptions> options)
        {
            this.options = options.Value;
        }
        public async Task SendAsync(Email message)
        {
            if (options.Enabled)
            {
                await Task.Run(() =>
                {
                    var fromAddress = new MailAddress(options.Email, options.Email);
                    var toAddress = new MailAddress(message.To);
                    string fromPassword = options.Password;
                    string body = message.Body;

                    //Values and credentials
                    var smtp = new SmtpClient
                    {
                        Host = options.Host,
                        Port = options.Port,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };

                    //Make a message and send
                    using var messageAux = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = message.Subject,
                        Body = body,
                        IsBodyHtml = message.IsBodyHtml
                    };
                    smtp.Send(messageAux);
                });
            }
        }
    }
}
