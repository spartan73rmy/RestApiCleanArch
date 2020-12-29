using RestApiCleanArch.Application.UseCases.Plagas.Queries.GetPlagas;
using RestApiCleanArch.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RestApiCleanArch.WebUi.FunctionalTests.Controllers.Plaga
{
    public class GetPlagas : BaseTestController
    {
        public GetPlagas(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("Admin")]
        [InlineData("User")]
        public async Task GetPlagasListCorrectamente(string username)
        {
            string pass = "123";
            var client = await GetAuthenticatedClientAsync(username, pass);
            var response = await client.GetAsync("/api/Plaga/GetPlagas");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetPlagasResponse>(response);

            Assert.IsType<GetPlagasResponse>(result);
            Assert.True(result.Plagas.Count > 0);
        }

        [Theory]
        [InlineData("Visor")]
        [InlineData("Productor")]
        public async Task GetPlagasNotAutorized(string username)
        {
            string pass = "123";
            var client = await GetAuthenticatedClientAsync(username, pass);
            var response = await client.GetAsync("/api/Plaga/GetPlagas");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetPlagasAnonymousNotAutorized()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/Plaga/GetPlagas");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
