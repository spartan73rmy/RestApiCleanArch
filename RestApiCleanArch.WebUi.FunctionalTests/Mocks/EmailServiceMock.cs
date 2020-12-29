using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Notifications.Models;
using System.Threading.Tasks;

namespace RestApiCleanArch.WebUi.FunctionalTests.Mocks
{
    public class EmailServiceMock : IEmailService
    {
        public Task SendAsync(Email message)
        {
            return Task.CompletedTask;
        }
    }
}