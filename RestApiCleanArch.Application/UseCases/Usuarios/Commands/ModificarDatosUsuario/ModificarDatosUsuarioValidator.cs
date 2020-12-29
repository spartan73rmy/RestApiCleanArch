using FluentValidation;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.ModificarDatosUsuario
{
    public class ModificarDatosUsuarioValidator : AbstractValidator<ModificarDatosUsuarioCommand>
    {
        public ModificarDatosUsuarioValidator()
        {
            RuleFor(el => el.IdUsuario).NotEmpty().GreaterThan(0);
            RuleFor(el => el.Nombre).MaximumLength(20).NotEmpty();
            RuleFor(el => el.ApellidoPaterno).MaximumLength(20).NotEmpty();
            RuleFor(el => el.ApellidoMaterno).MaximumLength(20).NotEmpty();
        }
    }
}