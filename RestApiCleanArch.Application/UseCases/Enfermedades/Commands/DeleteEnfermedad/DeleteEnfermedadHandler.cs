using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Enfermedades.Commands.DeleteEnfermedad
{
    public class DeleteEnfermedadHandler : IRequestHandler<DeleteEnfermedadCommand, DeleteEnfermedadResponse>
    {
        private readonly IRestApiCleanArchDbContext db;

        public DeleteEnfermedadHandler(IRestApiCleanArchDbContext db)
        {
            this.db = db;
        }

        public async Task<DeleteEnfermedadResponse> Handle(DeleteEnfermedadCommand request, CancellationToken cancellationToken)
        {
            Enfermedad entity = await db.Enfermedad.FindAsync(request.IdEnferemedad);

            db.Enfermedad.Remove(entity);
            await db.SaveChangesAsync(cancellationToken);

            return new DeleteEnfermedadResponse();
        }
    }
}
