using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Enfermedades.Queries.GetEnfermedades
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
