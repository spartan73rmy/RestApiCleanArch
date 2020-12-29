using RestApiCleanArch.Application.Notifications.Models;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(Email message);
    }
}
