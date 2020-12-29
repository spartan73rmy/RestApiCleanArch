using FitoReport.Application.Security;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Enfermedades.Commands.AgregarEnfermedad
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
