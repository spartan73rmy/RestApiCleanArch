using RestApiCleanArch.Domain.Enums;

namespace RestApiCleanArch.Application.Interfaces
{
    public interface IUserAccessor
    {
        int UserId { get; }
        bool IsAuthenticated { get; }
        TiposUsuario TipoUsuario { get; }
    }
}
