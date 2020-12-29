using FluentValidation;

namespace RestApiCleanArch.Application.UseCases.Archivos.Queries.DescargarArchivo
{
    public class DescargarArchivoValidator : AbstractValidator<DescargarArchivoQuery>
    {
        public DescargarArchivoValidator()
        {
            RuleFor(el => el.Hash).NotEmpty();
        }
    }
}