using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Notifications.Models;
using System;
using System.Threading.Tasks;

namespace RestApiCleanArch.Infraestructure
{
    public class PushNotificationService : IPushNotificationService
    {
        public Task SendAsync(PushNotification message)
        {
            throw new NotImplementedException();
        }
    }
}
