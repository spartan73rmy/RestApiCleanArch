using MediatR;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<CreateUsuarioResponse>
    {
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int TipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
    }
}