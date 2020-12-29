using FitoReport.Application.Exceptions;
using FitoReport.Application.Interfaces;
using FitoReport.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Reportes.Queries.GetReporte
{
    public class GetReporteValidator : AbstractValidator<GetReporteQuery>
    {
        private readonly IFitoReportDbContext db;

        public GetReporteValidator(IFitoReportDbContext db)
        {
            RuleFor(el => el.IdReporte).GreaterThan(0).NotEmpty();
            this.db = db;
        }
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<GetReporteQuery> context, CancellationToken cancellation = default)
        {
            var request = context.InstanceToValidate;
            var result = new ValidationResult();
            var entity = await db
                .Reporte
                .SingleOrDefaultAsync(el => el.Id == request.IdReporte);

            //If Single Report exist, get all
            if (entity == null)
            {
                throw new NotFoundException(nameof(Reporte), request.IdReporte);
            }
            return result;

        }
    }
}