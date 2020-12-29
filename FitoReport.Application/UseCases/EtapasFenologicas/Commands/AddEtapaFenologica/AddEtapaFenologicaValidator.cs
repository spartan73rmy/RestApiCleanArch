using FluentValidation;
namespace FitoReport.Application.UseCases.EtapasFenologicas.Commands.AddEtapaFenologica
{
    public class AddEtapaFenologicaValidator : AbstractValidator<AddEtapaFenologicaCommand>
    {
        public AddEtapaFenologicaValidator()
        {
            RuleFor(el => el.Nombre).NotEmpty();
        }
    }
}
