using FluentValidation;

namespace FitoReport.Application.UseCases.Plagas.Queries.GetPlagas
{
    public class GetPlagasValidator : AbstractValidator<GetPlagasQuery>
    {
        public GetPlagasValidator()
        {
        }
    }
}
