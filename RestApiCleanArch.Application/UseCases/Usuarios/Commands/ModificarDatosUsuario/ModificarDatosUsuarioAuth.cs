using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.ModificarDatosUsuario
{
    public class ModificarDatosUsuarioAuth : IAuthenticatedRequest<ModificarDatosUsuarioCommand, ModificarDatosUsuarioResponse>
    {
        public Task Validate(ModificarDatosUsuarioCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}