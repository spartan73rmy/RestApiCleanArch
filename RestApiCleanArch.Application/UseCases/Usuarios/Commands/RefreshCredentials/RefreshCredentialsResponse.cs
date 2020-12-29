using RestApiCleanArch.Domain.Enums;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.RefreshCredentials
{
    public class RefreshCredentialsResponse
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public TiposUsuario TipoUsuario { get; set; }
        public string RefreshToken { get; set; }
    }
}