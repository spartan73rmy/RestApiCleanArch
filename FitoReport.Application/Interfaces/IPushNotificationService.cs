using FitoReport.Application.Notifications.Models;
using System.Threading.Tasks;

namespace FitoReport.Application.Interfaces
{
    public interface IPushNotificationService
    {
        Task SendAsync(PushNotification message);
    }
}
