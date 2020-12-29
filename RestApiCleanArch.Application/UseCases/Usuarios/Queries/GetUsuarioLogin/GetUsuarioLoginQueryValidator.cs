using RestApiCleanArch.Application.Exceptions;
using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Common;
using RestApiCleanArch.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Queries.GetUsuarioLogin
{
    public class GetUsuarioLoginQueryValidator : AbstractValidator<GetUsuarioLoginQuery>
    {
        private readonly IRestApiCleanArchDbContext db;
        private readonly IDateTime dateTime;

        public GetUsuarioLoginQueryValidator(IRestApiCleanArchDbContext db, IDateTime dateTime)
        {
            RuleFor(el => el.NombreUsuario).NotEmpty();
            RuleFor(el => el.Password).NotEmpty();
            this.db = db;
            this.dateTime = dateTime;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<GetUsuarioLoginQuery> context, CancellationToken cancellation = default)
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

            // Comprobar el tiempo para desbloquear la cuenta
            if (entity.LockoutEnd > dateTime.Now)
            {
                int minutosRestantes = (entity.LockoutEnd - dateTime.Now).Minutes + 1;
                throw new ForbiddenException($"Sobrepasaste la cantidad de intentos de inicio de sesion, espera {minutosRestantes} minutos");
            }

            return result;
        }
    }
}