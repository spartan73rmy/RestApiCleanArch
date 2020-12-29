using RestApiCleanArch.Application.Exceptions;
using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Enfermedades.Commands.DeleteEnfermedad
{
    public class DeleteEnfermedadValidator : AbstractValidator<DeleteEnfermedadCommand>
    {
        private readonly IRestApiCleanArchDbContext db;

        public DeleteEnfermedadValidator(IRestApiCleanArchDbContext db)
        {
            RuleFor(el => el.IdEnferemedad).NotEmpty().GreaterThanOrEqualTo(0);
            this.db = db;
        }
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeleteEnfermedadCommand> context, CancellationToken cancellation = default)
        {
            var request = context.InstanceToValidate;
            var result = new ValidationResult();

            var entity = await db
                .Enfermedad
                .SingleOrDefaultAsync(el => el.Id == request.IdEnferemedad);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Enfermedad), request.IdEnferemedad);
            }

            return result;
        }
    }
}
