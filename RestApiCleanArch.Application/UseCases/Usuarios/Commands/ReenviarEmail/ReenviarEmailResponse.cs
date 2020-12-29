using RestApiCleanArch.Domain.Enums;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.ReenviarEmail
{
    public class ReenviarEmailResponse : NotificationResponse
    {
        public string Email { get; set; }
        public bool Confirmado { get; set; }
        public TiposUsuario TipoUsuario { get; set; }
        public string Token { get; set; }
    }
}