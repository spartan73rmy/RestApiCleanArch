using FitoReport.Application.Exceptions;
using FitoReport.Application.Interfaces;
using FitoReport.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Enfermedades.Commands.DeleteEnfermedad
{
    public class DeleteEnfermedadValidator : AbstractValidator<DeleteEnfermedadCommand>
    {
        private readonly IFitoReportDbContext db;

        public DeleteEnfermedadValidator(IFitoReportDbContext db)
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
