using FluentValidation;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.ConfirmarEmail
{
    public class ConfirmarEmailCommandValidator : AbstractValidator<ConfirmarEmailCommand>
    {
        public ConfirmarEmailCommandValidator()
        {
            RuleFor(el => el.Token).NotEmpty();
        }
    }
}