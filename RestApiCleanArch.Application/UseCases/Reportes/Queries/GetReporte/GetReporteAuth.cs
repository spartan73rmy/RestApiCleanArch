using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Reportes.Queries.GetReporte
{
    public class GetReporteAuth : IProductorRequest<GetReporteQuery, GetReporteResponse>
    {
        public GetReporteAuth()
        {
        }

        public async Task Validate(GetReporteQuery request, ValidationResult validationResult)
        {
            await Task.CompletedTask;
        }
    }
}