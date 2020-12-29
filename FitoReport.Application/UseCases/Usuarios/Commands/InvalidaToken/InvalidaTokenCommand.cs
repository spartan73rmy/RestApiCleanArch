using MediatR;

namespace FitoReport.Application.UseCases.Usuarios.Commands.InvalidaToken
{
    public class InvalidaTokenCommand : IRequest<InvalidaTokenResponse>
    {
        public string RefreshToken { get; set; }
    }
}