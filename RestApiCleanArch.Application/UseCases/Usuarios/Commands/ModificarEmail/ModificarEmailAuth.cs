using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.ModificarEmail
{
    public class ModificarEmailAuth : IAuthenticatedRequest<ModificarEmailCommand, ModificarEmailResponse>
    {
        public Task Validate(ModificarEmailCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}