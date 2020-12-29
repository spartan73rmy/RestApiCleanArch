using RestApiCleanArch.Application.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioCommandValidator : AbstractValidator<CreateUsuarioCommand>
    {
        private readonly IRestApiCleanArchDbContext db;

        public CreateUsuarioCommandValidator(IRestApiCleanArchDbContext db)
        {
            this.db = db;
            RuleFor(el => el.NombreUsuario).Matches("^[a-zA-Z]+(?:[_-]?[a-zA-Z0-9])*$").MaximumLength(20).NotEmpty();
            RuleFor(el => el.Email).EmailAddress().MaximumLength(50).NotEmpty();
            RuleFor(el => el.Password).NotNull().NotEmpty();
            RuleFor(el => el.TipoUsuario).GreaterThanOrEqualTo(0);
            RuleFor(el => el.Nombre).MaximumLength(20).NotEmpty();
            RuleFor(el => el.ApellidoPaterno).MaximumLength(20).NotEmpty();
            RuleFor(el => el.ApellidoMaterno).MaximumLength(20).NotEmpty();
        }

        public override async Task<FluentValidation.Results.ValidationResult> ValidateAsync(ValidationContext<CreateUsuarioCommand> context, CancellationToken cancellation = default)
        {
            var result = new FluentValidation.Results.ValidationResult();
            var entity = context.InstanceToValidate;

            string normalizedEmail = entity.Email.ToUpper();
            string normalizedUser = entity.NombreUsuario.ToUpper();

            bool nombreUsuarioRegistrado = await db
                .Usuario
                .AnyAsync(el => el.NormalizedUserName == normalizedUser, cancellation);

            bool emailRegistrado = await db
                .Usuario
                .AnyAsync(el => el.NormalizedEmail == normalizedEmail, cancellation);

            if (nombreUsuarioRegistrado)
            {
                result.Errors.Add(new ValidationFailure(nameof(entity.NombreUsuario), "El nombre de usuario ya se encuentra registrado"));
            }

            if (emailRegistrado)
            {
                result.Errors.Add(new ValidationFailure(nameof(entity.Email), "El email ya se encuentra registrado"));
            }
            return result;
        }
    }
}