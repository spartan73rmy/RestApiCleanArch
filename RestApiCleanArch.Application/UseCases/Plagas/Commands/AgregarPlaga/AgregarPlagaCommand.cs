using MediatR;

namespace RestApiCleanArch.Application.UseCases.Plagas.Commands.AgregarPlaga
{
    public class AgregarPlagaCommand : IRequest<AgregarPlagaResponse>
    {
        public string Nombre { get; set; }
    }
}
