namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.ModificarDatosUsuario
{
    public class ModificarDatosUsuarioResponse
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
    }
}