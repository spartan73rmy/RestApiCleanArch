using MediatR;

namespace FitoReport.Application.UseCases.Plagas.Commands.AgregarPlaga
{
    public class AgregarPlagaCommand : IRequest<AgregarPlagaResponse>
    {
        public string Nombre { get; set; }
    }
}
