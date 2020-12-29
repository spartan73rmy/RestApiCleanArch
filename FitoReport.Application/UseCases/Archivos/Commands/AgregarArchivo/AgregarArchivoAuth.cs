using FitoReport.Application.Security;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Archivos.Commands.AgregarArchivo
{
    public class AgregarArchivoAuth : IAuthenticatedRequest<AgregarArchivoCommand, AgregarArchivoResponse>
    {
        public Task Validate(AgregarArchivoCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}