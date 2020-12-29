using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Reportes.Commands.AgregarArchivo
{
    public class AgregarArchivoAuth : IAuthenticatedRequest<AgregarArchivoCommand, AgregarArchivoResponse>
    {
        private readonly IRestApiCleanArchDbContext db;
        private readonly IUserAccessor currentUser;

        public AgregarArchivoAuth(IRestApiCleanArchDbContext db, IUserAccessor currentUser)
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