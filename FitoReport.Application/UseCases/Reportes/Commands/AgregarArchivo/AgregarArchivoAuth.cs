using FitoReport.Application.Interfaces;
using FitoReport.Application.Security;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarArchivo
{
    public class AgregarArchivoAuth : IAuthenticatedRequest<AgregarArchivoCommand, AgregarArchivoResponse>
    {
        private readonly IFitoReportDbContext db;
        private readonly IUserAccessor currentUser;

        public AgregarArchivoAuth(IFitoReportDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(AgregarArchivoCommand request, ValidationResult validationResult)
        {
            await Task.CompletedTask;
            //int autorActividad = await db
            //   .ActividadCurso
            //   .Where(el => el.Id == request.IdActividad)
            //   .Select(el => el.Unidad.Curso.IdMaestro)
            //   .SingleOrDefaultAsync();

            //if (autorActividad != currentUser.UserId)
            //{
            //    validationResult.Errors.Add("No creaste la actividad");
            //}
        }
    }
}