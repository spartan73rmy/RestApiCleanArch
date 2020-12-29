using FluentValidation;

namespace FitoReport.Application.UseCases.Usuarios.Commands.RecuperaPassword
{
    public class RecuperaPasswordValidator : AbstractValidator<RecuperaPasswordCommand>
    {
        public RecuperaPasswordValidator()
        {
            RuleFor(el => el.Token).NotEmpty();
            RuleFor(el => el.Password).NotEmpty();
        }
    }
}