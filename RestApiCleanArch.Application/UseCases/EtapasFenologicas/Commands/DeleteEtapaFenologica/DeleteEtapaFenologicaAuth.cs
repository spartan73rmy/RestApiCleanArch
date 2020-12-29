using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.EtapasFenologicas.Commands.DeleteEtapaFenologica
{
    public class DeleteEtapaFenologicaAuth : IUserRequest<DeleteEtapaFenologicaCommand, DeleteEtapaFenologicaResponse>
    {
        public DeleteEtapaFenologicaAuth()
        {
        }
        
        public Task Validate(DeleteEtapaFenologicaCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
