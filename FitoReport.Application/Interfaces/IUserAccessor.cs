using FitoReport.Domain.Enums;

namespace FitoReport.Application.Interfaces
{
    public interface IUserAccessor
    {
        int UserId { get; }
        bool IsAuthenticated { get; }
        TiposUsuario TipoUsuario { get; }
    }
}
