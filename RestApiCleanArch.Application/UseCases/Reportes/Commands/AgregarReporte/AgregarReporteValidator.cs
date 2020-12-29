using FluentValidation;

namespace RestApiCleanArch.Application.UseCases.Reportes.Commands.AgregarReporte
{
    public class AgregarReporteValidator : AbstractValidator<AgregarReporteCommand>
    {
        public AgregarReporteValidator()
        {
            RuleFor(el => el.Reportes.Count).GreaterThan(0);
        }
    }
}