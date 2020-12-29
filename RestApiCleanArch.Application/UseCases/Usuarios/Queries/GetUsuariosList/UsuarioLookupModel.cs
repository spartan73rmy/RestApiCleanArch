using RestApiCleanArch.Domain.Enums;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Queries.GetUsuariosList
{
    public class UsuarioLookupModel
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public TiposUsuario TipoUsuario { get; set; }
        public bool Confirmado { get; set; }
    }
}