using MediatR;
namespace FitoReport.Application.UseCases.EtapasFenologicas.Commands.AddEtapaFenologica
{
    public class AddEtapaFenologicaCommand : IRequest<AddEtapaFenologicaResponse>
    {
        public string Nombre { get; set; }
    }
}
