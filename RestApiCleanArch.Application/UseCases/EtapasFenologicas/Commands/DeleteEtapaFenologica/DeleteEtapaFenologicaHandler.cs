using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.EtapasFenologicas.Commands.DeleteEtapaFenologica
{
    public class DeleteEtapaFenologicaHandler : IRequestHandler<DeleteEtapaFenologicaCommand, DeleteEtapaFenologicaResponse>
    {
        private readonly IRestApiCleanArchDbContext db;

        public DeleteEtapaFenologicaHandler(IRestApiCleanArchDbContext db)
        {
            this.db = db;
        }

        public async Task<DeleteEtapaFenologicaResponse> Handle(DeleteEtapaFenologicaCommand request, CancellationToken cancellationToken)
        {
            EtapaFenologica entity = await db.EtapaFenologica.FindAsync(request.IdEtapa);

            db.EtapaFenologica.Remove(entity);
            await db.SaveChangesAsync(cancellationToken);

            return new DeleteEtapaFenologicaResponse();
        }
    }
}
