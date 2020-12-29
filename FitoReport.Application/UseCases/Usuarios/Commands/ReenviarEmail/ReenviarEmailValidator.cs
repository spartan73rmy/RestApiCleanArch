using FluentValidation;

namespace FitoReport.Application.UseCases.Usuarios.Commands.ReenviarEmail
{
    public class ReenviarEmailValidator : AbstractValidator<ReenviarEmailCommand>
    {
        public ReenviarEmailValidator()
        {
            RuleFor(el => el.Email).EmailAddress().MaximumLength(50).NotEmpty();
        }
    }
}