using FitoReport.Application.Interfaces;
using FitoReport.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Enfermedades.Commands.DeleteEnfermedad
{
    public class DeleteEnfermedadHandler : IRequestHandler<DeleteEnfermedadCommand, DeleteEnfermedadResponse>
    {
        private readonly IFitoReportDbContext db;

        public DeleteEnfermedadHandler(IFitoReportDbContext db)
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
