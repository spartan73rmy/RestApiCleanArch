using RestApiCleanArch.Application.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.ModificarEmail
{
    public class ModificarEmailValidator : AbstractValidator<ModificarEmailCommand>
    {
        private readonly IRestApiCleanArchDbContext db;

        public ModificarEmailValidator(IRestApiCleanArchDbContext db)
        {
            this.db = db;
            RuleFor(el => el.NuevoEmail).EmailAddress().MaximumLength(50).NotEmpty();
            RuleFor(el => el.Password).NotNull().NotEmpty();
        }

        public override async Task<FluentValidation.Results.ValidationResult> ValidateAsync(ValidationContext<ModificarEmailCommand> context, CancellationToken cancellation = default)
        {
            var result = new FluentValidation.Results.ValidationResult();
            var entity = context.InstanceToValidate;

            string normalizedEmail = entity.NuevoEmail.ToUpper();

            bool oldUser = await db
                .Usuario
                .AnyAsync(el => el.NormalizedEmail == normalizedEmail, cancellation);

            if (oldUser)
            {
                result.Errors.Add(new ValidationFailure(nameof(entity.NuevoEmail), "El email ya se encuentra registrado"));
            }

            return result;
        }
    }
}