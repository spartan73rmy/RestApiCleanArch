using MediatR;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.ModificarPassword
{
    public class ModificarPasswordCommand : IRequest<ModificarPasswordResponse>
    {
        public string PasswordActual { get; set; }
        public string PasswordNuevo { get; set; }
    }
}