using FluentValidation;

namespace RestApiCleanArch.Application.UseCases.Plagas.Commands.AgregarPlaga
{
    public class AgregarPlagaValidator : AbstractValidator<AgregarPlagaCommand>
    {
        public AgregarPlagaValidator()
        {
            RuleFor(el => el.Nombre).NotEmpty();
        }
    }
}
