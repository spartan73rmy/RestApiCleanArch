using FitoReport.Application.Notifications.Models;
using System.Threading.Tasks;

namespace FitoReport.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(Email message);
    }
}
