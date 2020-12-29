using MediatR;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.RecuperaPassword
{
    public class RecuperaPasswordCommand : IRequest<RecuperaPasswordResponse>
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
}