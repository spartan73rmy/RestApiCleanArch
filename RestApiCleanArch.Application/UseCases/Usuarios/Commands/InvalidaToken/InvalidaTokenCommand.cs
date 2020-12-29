using MediatR;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.InvalidaToken
{
    public class InvalidaTokenCommand : IRequest<InvalidaTokenResponse>
    {
        public string RefreshToken { get; set; }
    }
}