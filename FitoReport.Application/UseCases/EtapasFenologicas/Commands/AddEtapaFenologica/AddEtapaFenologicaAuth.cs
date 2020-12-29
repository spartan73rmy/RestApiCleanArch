using FitoReport.Application.Security;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.EtapasFenologicas.Commands.AddEtapaFenologica
{
    public class AddEtapaFenologicaAuth : IUserRequest<AddEtapaFenologicaCommand, AddEtapaFenologicaResponse>
    {

        public AddEtapaFenologicaAuth()
        {
        }
        
        public Task Validate(AddEtapaFenologicaCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
