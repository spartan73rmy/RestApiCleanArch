using RestApiCleanArch.Application.Interfaces;
using FluentValidation;

namespace RestApiCleanArch.Application.UseCases.Reportes.Commands.AgregarArchivo
{
    public class AgregarArchivoValidator : AbstractValidator<AgregarArchivoCommand>
    {
        private readonly IRestApiCleanArchDbContext db;

        public AgregarArchivoValidator(IRestApiCleanArchDbContext db)
        {
            RuleFor(el => el.Archivo).NotEmpty();
            RuleFor(el => el.IdActividad).NotEmpty().GreaterThan(0);
            this.db = db;
        }
    }
}