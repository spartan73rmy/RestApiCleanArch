using FitoReport.Application.Interfaces;
using FitoReport.Application.Notifications.Models;
using System.Threading.Tasks;

namespace FitoReport.WebUi.FunctionalTests.Mocks
{
    public class EmailServiceMock : IEmailService
    {
        public Task SendAsync(Email message)
        {
            return Task.CompletedTask;
        }
    }
}