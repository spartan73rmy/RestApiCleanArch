using FluentValidation;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.RecuperaPasswordGeneraToken
{
    public class RecuperaPasswordGeneraTokenValidator : AbstractValidator<RecuperaPasswordGeneraTokenCommand>
    {
        public RecuperaPasswordGeneraTokenValidator()
        {
            RuleFor(el => el.Email).EmailAddress();
        }
    }
}