using FluentValidation;

namespace FitoReport.Application.UseCases.Enfermedades.Commands.AgregarEnfermedad
{
    public class AgregarEnfermedadValidator : AbstractValidator<AgregarEnfermedadCommand>
    {
        public AgregarEnfermedadValidator()
        {
            RuleFor(el => el.Nombre).NotEmpty();
        }
    }
}
