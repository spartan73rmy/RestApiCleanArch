using FluentValidation;

namespace FitoReport.Application.UseCases.Usuarios.Commands.InvalidaToken
{
    public class InvalidaTokenValidator : AbstractValidator<InvalidaTokenCommand>
    {
        public InvalidaTokenValidator()
        {
            RuleFor(el => el.RefreshToken).NotEmpty();
        }
    }
}