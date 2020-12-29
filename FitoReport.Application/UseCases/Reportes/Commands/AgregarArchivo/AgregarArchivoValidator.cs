using FitoReport.Application.Interfaces;
using FluentValidation;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarArchivo
{
    public class AgregarArchivoValidator : AbstractValidator<AgregarArchivoCommand>
    {
        private readonly IFitoReportDbContext db;

        public AgregarArchivoValidator(IFitoReportDbContext db)
        {
            RuleFor(el => el.Archivo).NotEmpty();
            RuleFor(el => el.IdActividad).NotEmpty().GreaterThan(0);
            this.db = db;
        }
    }
}