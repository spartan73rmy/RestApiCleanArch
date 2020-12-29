using FitoReport.Application.Interfaces;
using FitoReport.Application.Notifications.Models;
using System;
using System.Threading.Tasks;

namespace FitoReport.Infraestructure
{
    public class PushNotificationService : IPushNotificationService
    {
        public Task SendAsync(PushNotification message)
        {
            throw new NotImplementedException();
        }
    }
}
