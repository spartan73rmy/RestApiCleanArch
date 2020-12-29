using FitoReport.Application.Security;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Enfermedades.Queries.GetEnfermedades
{
    public class GetEnfermedadesAuth : IUserRequest<GetEnfermedadesQuery, GetEnfermedadesResponse>
    {

        public GetEnfermedadesAuth()
        {
        }

        public Task Validate(GetEnfermedadesQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
