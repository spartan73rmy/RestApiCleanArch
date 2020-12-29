using RestApiCleanArch.Application.Exceptions;
using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Plagas.Commands.DeletePlaga
{
    public class DeletePlagaValidator : AbstractValidator<DeletePlagaCommand>
    {
        private readonly IRestApiCleanArchDbContext db;

        public DeletePlagaValidator(IRestApiCleanArchDbContext db)
        {
            RuleFor(el => el.IdPlaga).NotEmpty().GreaterThanOrEqualTo(0);
            this.db = db;
        }
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeletePlagaCommand> context, CancellationToken cancellation = default)
        {
            var request = context.InstanceToValidate;
            var result = new ValidationResult();

            var entity = await db
                .Plaga
                .SingleOrDefaultAsync(el => el.Id == request.IdPlaga);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Plaga), request.IdPlaga);
            }

            return result;
        }
    }
}
