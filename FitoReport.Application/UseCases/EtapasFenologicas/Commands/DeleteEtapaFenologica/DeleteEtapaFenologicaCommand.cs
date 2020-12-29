using MediatR;

namespace FitoReport.Application.UseCases.EtapasFenologicas.Commands.DeleteEtapaFenologica
{
    public class DeleteEtapaFenologicaCommand : IRequest<DeleteEtapaFenologicaResponse>
    {
        public int IdEtapa { get; set; }
    }
}
