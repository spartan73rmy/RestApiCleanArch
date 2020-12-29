using MediatR;

namespace FitoReport.Application.UseCases.Usuarios.Commands.ReenviarEmail
{
    public class ReenviarEmailCommand : IRequest<ReenviarEmailResponse>
    {
        public string Email { get; set; }
    }
}