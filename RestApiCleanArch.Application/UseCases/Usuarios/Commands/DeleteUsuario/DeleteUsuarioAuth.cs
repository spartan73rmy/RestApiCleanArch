using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioAuth : IAdminRequest<DeleteUsuarioCommand, DeleteUsuarioResponse>
    {
        private readonly IRestApiCleanArchDbContext db;
        private readonly IUserAccessor currentUser;

        public DeleteUsuarioAuth(IRestApiCleanArchDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public Task Validate(DeleteUsuarioCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
