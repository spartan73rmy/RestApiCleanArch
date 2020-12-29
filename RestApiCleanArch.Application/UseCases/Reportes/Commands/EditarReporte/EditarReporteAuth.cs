using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Reportes.Commands.EditarReporte
{
    public class EditarReporteAuth : IAuthenticatedRequest<EditarReporteCommand, EditarReporteResponse>
    {
        private readonly IRestApiCleanArchDbContext db;
        private readonly IUserAccessor currentUser;

        public EditarReporteAuth(IRestApiCleanArchDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(EditarReporteCommand request, ValidationResult validationResult)
        {
            await Task.CompletedTask;
            //var unidad = await db
            //        .ActividadCurso
            //        .Where(el => el.Id == request.IdActividad)
            //        .Select(el => new { el.Unidad.Curso.IdMaestro, el.BloquearEnvios })
            //        .SingleOrDefaultAsync();

            //if (unidad.IdMaestro != currentUser.UserId)
            //{
            //    validationResult.Errors.Add("Maestro No Autorizado");
            //}
        }
    }
}