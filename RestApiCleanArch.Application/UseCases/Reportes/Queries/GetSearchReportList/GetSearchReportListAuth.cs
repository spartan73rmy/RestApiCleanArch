using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Reportes.Queries.GetSearchReportList
{
    public class GetSearchReportListAuth : IAuthenticatedRequest<GetSearchReportListQuery, GetSearchReportListResponse>
    {
        private readonly IRestApiCleanArchDbContext db;
        private readonly IUserAccessor currentUser;

        public GetSearchReportListAuth(IRestApiCleanArchDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public Task Validate(GetSearchReportListQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
