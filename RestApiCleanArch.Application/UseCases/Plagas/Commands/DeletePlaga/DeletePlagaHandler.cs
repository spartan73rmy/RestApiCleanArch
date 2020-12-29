using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Plagas.Commands.DeletePlaga
{
    public class DeletePlagaHandler : IRequestHandler<DeletePlagaCommand, DeletePlagaResponse>
    {
        private readonly IRestApiCleanArchDbContext db;

        public DeletePlagaHandler(IRestApiCleanArchDbContext db)
        {
            this.db = db;
        }

        public async Task<DeletePlagaResponse> Handle(DeletePlagaCommand request, CancellationToken cancellationToken)
        {
            Plaga entity = await db.Plaga.FindAsync(request.IdPlaga);

            db.Plaga.Remove(entity);
            await db.SaveChangesAsync(cancellationToken);

            return new DeletePlagaResponse();
        }
    }
}
