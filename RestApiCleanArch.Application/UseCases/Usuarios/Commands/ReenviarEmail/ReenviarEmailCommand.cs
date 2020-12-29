using MediatR;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.ReenviarEmail
{
    public class ReenviarEmailCommand : IRequest<ReenviarEmailResponse>
    {
        public string Email { get; set; }
    }
}