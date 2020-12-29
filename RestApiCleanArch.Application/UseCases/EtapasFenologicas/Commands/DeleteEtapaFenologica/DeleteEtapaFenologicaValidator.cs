using RestApiCleanArch.Application.Exceptions;
using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.EtapasFenologicas.Commands.DeleteEtapaFenologica
{
    public class DeleteEtapaFenologicaValidator : AbstractValidator<DeleteEtapaFenologicaCommand>
    {
        private readonly IRestApiCleanArchDbContext db;

        public DeleteEtapaFenologicaValidator(IRestApiCleanArchDbContext db)
        {
            RuleFor(el => el.IdEtapa).NotEmpty().GreaterThanOrEqualTo(0);
            this.db = db;
        }
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeleteEtapaFenologicaCommand> context, CancellationToken cancellation = default)
        {
            var request = context.InstanceToValidate;
            var result = new ValidationResult();

            var entity = await db
                .EtapaFenologica
                .SingleOrDefaultAsync(el => el.Id == request.IdEtapa);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EtapaFenologica), request.IdEtapa);
            }

            return result;
        }
    }
}
