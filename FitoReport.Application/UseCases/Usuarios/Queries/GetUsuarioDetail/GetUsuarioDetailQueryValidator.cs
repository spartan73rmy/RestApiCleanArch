using FluentValidation;

namespace FitoReport.Application.UseCases.Usuarios.Queries.GetUsuarioDetail
{
    public class GetUsuarioDetailQueryValidator : AbstractValidator<GetUsuarioDetailQuery>
    {
        public GetUsuarioDetailQueryValidator()
        {
            RuleFor(el => el.IdUsuario).NotEmpty().GreaterThan(0);
        }
    }
}