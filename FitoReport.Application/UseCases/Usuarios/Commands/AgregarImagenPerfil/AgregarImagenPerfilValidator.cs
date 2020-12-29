using FitoReport.Application.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Usuarios.Commands.AgregarImagenPerfil
{
    public class AgregarImagenPerfilValidator : AbstractValidator<AgregarImagenPerfilCommand>
    {
        private readonly IFitoReportDbContext db;

        public AgregarImagenPerfilValidator(IFitoReportDbContext db)
        {
            RuleFor(el => el.Imagen).NotEmpty();
            this.db = db;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<AgregarImagenPerfilCommand> context, CancellationToken cancellation = default)
        {
            var validations = new ValidationResult();
            var request = context.InstanceToValidate;

            var archivo = await db
                .ArchivoUsuario
                .SingleOrDefaultAsync(el => el.Hash == request.Imagen);

            if (archivo == null)
            {
                validations.Errors.Add(new ValidationFailure(nameof(request.Imagen), "La Imagen no Existe"));
            }
            else if (!archivo.ContentType.ToLower().StartsWith("image"))
            {
                validations.Errors.Add(new ValidationFailure(nameof(request.Imagen), "No es una Imagen"));
            }

            return validations;
        }
    }
}