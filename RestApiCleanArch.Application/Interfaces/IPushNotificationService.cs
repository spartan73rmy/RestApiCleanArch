using RestApiCleanArch.Application.Notifications.Models;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.Interfaces
{
    public interface IPushNotificationService
    {
        Task SendAsync(PushNotification message);
    }
}
