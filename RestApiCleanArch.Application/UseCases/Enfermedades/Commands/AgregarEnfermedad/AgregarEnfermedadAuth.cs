using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Enfermedades.Commands.AgregarEnfermedad
{
    public class AgregarEnfermedadAuth : IUserRequest<AgregarEnfermedadCommand, AgregarEnfermedadResponse>
    {
        public AgregarEnfermedadAuth()
        {
        }

        public Task Validate(AgregarEnfermedadCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
