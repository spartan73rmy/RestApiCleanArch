using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace RestApiCleanArch.WebUi.FunctionalTests.Common
{
    public abstract class BaseTestController : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> factory;

        public BaseTestController(CustomWebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }
        public HttpClient GetClient(Action<IServiceCollection> configuration = null)
        {
            return factory.GetAnonymousClient(configuration);
        }
        public async Task<HttpClient> GetAuthenticatedClientAsync(string username, string pass, Action<IServiceCollection> configuration = null)
        {
            return await factory.GetAuthenticatedClientAsync(username, pass, configuration);
        }
        public async Task<HttpClient> GetAdminClientAsync(Action<IServiceCollection> configuration = null)
        {
            return await factory.GetAuthenticatedClientAsync("Admin", "123", configuration);
        }
        public async Task<HttpClient> GetUserClientAsync(Action<IServiceCollection> configuration = null)
        {
            return await factory.GetAuthenticatedClientAsync("User", "123", configuration);
        }
        public async Task<HttpClient> GetProductorClientAsync(Action<IServiceCollection> configuration = null)
        {
            return await factory.GetAuthenticatedClientAsync("Productor", "123", configuration);
        }
        public async Task<HttpClient> GetVisorClientAsync(Action<IServiceCollection> configuration = null)
        {
            return await factory.GetAuthenticatedClientAsync("Visor", "123", configuration);
        }
    }
}
