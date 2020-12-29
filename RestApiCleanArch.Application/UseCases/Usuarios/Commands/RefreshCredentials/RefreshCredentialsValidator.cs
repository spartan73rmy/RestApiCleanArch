using FluentValidation;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.RefreshCredentials
{
    public class RefreshCredentialsValidator : AbstractValidator<RefreshCredentialsCommand>
    {
        public RefreshCredentialsValidator()
        {
            RuleFor(el => el.RefreshToken).NotEmpty();
            RuleFor(el => el.Token).NotEmpty();
        }
    }
}