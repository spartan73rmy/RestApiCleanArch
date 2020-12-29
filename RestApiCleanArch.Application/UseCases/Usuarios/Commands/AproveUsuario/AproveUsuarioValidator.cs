using RestApiCleanArch.Application.Exceptions;
using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.AproveUsuario
{
    public class AproveUsuarioValidator : AbstractValidator<AproveUsuarioCommand>
    {
        private readonly IRestApiCleanArchDbContext db;

        public AproveUsuarioValidator(IRestApiCleanArchDbContext db)
        {
            RuleFor(el => el.NombreUsuario).Matches("^[a-zA-Z]+(?:[_-]?[a-zA-Z0-9])*$").MaximumLength(20).NotEmpty();
            this.db = db;
        }
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<AproveUsuarioCommand> context, CancellationToken cancellation = default)
        {
            var request = context.InstanceToValidate;
            var result = new ValidationResult();

            var entity = await db
                .Usuario
                .SingleOrDefaultAsync(el => el.NombreUsuario == request.NombreUsuario || el.Email == request.NombreUsuario);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.NombreUsuario);
            }

            return result;
        }
    }
}
