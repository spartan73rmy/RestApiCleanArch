using MediatR;

namespace RestApiCleanArch.Application.UseCases.EtapasFenologicas.Commands.DeleteEtapaFenologica
{
    public class DeleteEtapaFenologicaCommand : IRequest<DeleteEtapaFenologicaResponse>
    {
        public int IdEtapa { get; set; }
    }
}
