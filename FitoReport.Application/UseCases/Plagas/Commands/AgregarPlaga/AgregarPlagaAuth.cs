using FitoReport.Application.Security;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Plagas.Commands.AgregarPlaga
{
    public class AgregarPlagaAuth : IUserRequest<AgregarPlagaCommand, AgregarPlagaResponse>
    {
        public AgregarPlagaAuth()
        {
        }

        public Task Validate(AgregarPlagaCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
