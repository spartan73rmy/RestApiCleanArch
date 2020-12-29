using MediatR;

namespace FitoReport.Application.UseCases.Plagas.Commands.DeletePlaga
{
    public class DeletePlagaCommand : IRequest<DeletePlagaResponse>
    {
        public int IdPlaga { get; set; }
    }
}
