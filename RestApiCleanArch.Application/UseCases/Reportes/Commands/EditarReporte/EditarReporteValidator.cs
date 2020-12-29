using RestApiCleanArch.Common;
using FluentValidation;

namespace RestApiCleanArch.Application.UseCases.Reportes.Commands.EditarReporte
{
    public class EditarReporteValidator : AbstractValidator<EditarReporteCommand>
    {
        public EditarReporteValidator(IDateTime dateTime)
        {
            //    RuleFor(el => el.IdActividad).NotEmpty().GreaterThan(0);
            //    RuleFor(el => el.IdTipoActividad).NotEmpty().GreaterThan(0);
            //    RuleFor(el => el.Titulo).NotEmpty();
            //    RuleFor(el => el.Valor).NotEmpty().GreaterThan(0);
            //    RuleFor(el => el.Contenido).NotEmpty();
            //    RuleFor(el => el.FechaLimite).NotEmpty().GreaterThan(el => dateTime.Now);
            //    RuleFor(el => el.FechaActivacion).LessThan(el => el.FechaLimite).When(el => el.FechaActivacion.HasValue);
        }
    }
}
