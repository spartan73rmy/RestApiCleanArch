using MediatR;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.RecuperaPasswordGeneraToken
{
    public class RecuperaPasswordGeneraTokenCommand : IRequest<RecuperaPasswordGeneraTokenResponse>
    {
        public string Email { get; set; }
    }
}