namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioResponse : NotificationResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
    }
}