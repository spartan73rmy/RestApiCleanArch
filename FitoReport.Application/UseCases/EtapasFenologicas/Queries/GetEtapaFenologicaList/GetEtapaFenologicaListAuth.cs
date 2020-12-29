using FitoReport.Application.Security;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.EtapasFenologicas.Queries.GetEtapaFenologicaList
{
    public class GetEtapaFenologicaListAuth : IUserRequest<GetEtapaFenologicaListQuery, GetEtapaFenologicaListResponse>
    {

        public GetEtapaFenologicaListAuth()
        {
        }

        public Task Validate(GetEtapaFenologicaListQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
