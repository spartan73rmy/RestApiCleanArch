using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Enfermedades.Commands.DeleteEnfermedad
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
