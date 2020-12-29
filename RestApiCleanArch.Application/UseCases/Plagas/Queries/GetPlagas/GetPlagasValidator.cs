using FluentValidation;

namespace RestApiCleanArch.Application.UseCases.Plagas.Queries.GetPlagas
{
    public class GetPlagasValidator : AbstractValidator<GetPlagasQuery>
    {
        public GetPlagasValidator()
        {
        }
    }
}
