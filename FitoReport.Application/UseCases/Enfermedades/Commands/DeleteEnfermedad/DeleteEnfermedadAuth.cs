using FitoReport.Application.Interfaces;
using FitoReport.Application.Security;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Enfermedades.Commands.DeleteEnfermedad
{
    public class DeleteEnfermedadAuth : IUserRequest<DeleteEnfermedadCommand, DeleteEnfermedadResponse>
    {

        public DeleteEnfermedadAuth()
        {
        }
        
        public Task Validate(DeleteEnfermedadCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
