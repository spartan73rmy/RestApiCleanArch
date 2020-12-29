using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Security;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Commands.AproveUsuario
{
    public class AproveUsuarioAuth : IAdminRequest<AproveUsuarioCommand, AproveUsuarioResponse>
    {
        private readonly IRestApiCleanArchDbContext db;
        private readonly IUserAccessor currentUser;

        public AproveUsuarioAuth(IRestApiCleanArchDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public Task Validate(AproveUsuarioCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
