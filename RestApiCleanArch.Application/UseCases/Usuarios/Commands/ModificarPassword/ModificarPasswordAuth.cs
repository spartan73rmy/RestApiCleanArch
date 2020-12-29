using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.ModificarPassword
{
    public class ModificarPasswordAuth : IAuthenticatedRequest<ModificarPasswordCommand, ModificarPasswordResponse>
    {
        public Task Validate(ModificarPasswordCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}