using FitoReport.Application.Interfaces;
using FitoReport.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Enfermedades.Commands.AgregarEnfermedad
{
    public class AgregarEnfermedadHandler : IRequestHandler<AgregarEnfermedadCommand, AgregarEnfermedadResponse>
    {
        private readonly IFitoReportDbContext db;

        public AgregarEnfermedadHandler(IFitoReportDbContext db)
        {
            this.db = db;
        }

        public async Task<AgregarEnfermedadResponse> Handle(AgregarEnfermedadCommand request, CancellationToken cancellationToken)
        {
            //Search if exist a Enfermedad with equals or similar name
            string nombre = NormalizeString(request.Nombre);
            Enfermedad oldEnfermedad = await
                db.Enfermedad.Where(el =>
                el.Nombre.Replace(" ", "").ToLower().Equals(nombre))
                .FirstOrDefaultAsync();

            if (oldEnfermedad == null)
            {
                Enfermedad newEnfermedad = new Enfermedad
                {
                    Nombre = request.Nombre
                };
                db.Enfermedad.Add(newEnfermedad);
            }
            else
            {
                oldEnfermedad.IsDeleted = false;
                oldEnfermedad.DeletedDate = null;
            }
            await db.SaveChangesAsync(cancellationToken);

            return new AgregarEnfermedadResponse();
        }
        private string NormalizeString(string toNormalize)
        {
            return NormalizeString(new[] { " ", ".", "," }, toNormalize);
        }
        private string NormalizeString(string[] charsToDelete, string toNormalize)
        {
            foreach (string item in charsToDelete)
            {
                toNormalize = toNormalize.Replace(
                   item, newValue: string.Empty);
            }
            return toNormalize.ToLower();
        }
    }
}
