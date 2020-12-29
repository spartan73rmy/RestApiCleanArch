using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.EtapasFenologicas.Commands.AddEtapaFenologica
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
