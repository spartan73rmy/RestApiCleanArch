using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Reportes.Commands.AgregarReporte
{
    public class AgregarReporteAuth : IAuthenticatedRequest<AgregarReporteCommand, AgregarReporteResponse>
    {
        private readonly IUserAccessor currentUser;
        private readonly IRestApiCleanArchDbContext db;

        public AgregarReporteAuth(IUserAccessor currentUser, IRestApiCleanArchDbContext db)
        {
            this.currentUser = currentUser;
            this.db = db;
        }

        public async Task Validate(AgregarReporteCommand request, ValidationResult validationResult)
        {
            await Task.CompletedTask;
        }
    }
}