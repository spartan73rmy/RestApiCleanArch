using RestApiCleanArch.Application.UseCases.EtapasFenologicas.Queries.GetEtapaFenologicaList;
using RestApiCleanArch.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RestApiCleanArch.WebUi.FunctionalTests.Controllers.EtapaFenologica
{
    public class GetAllEtapas : BaseTestController
    {
        private readonly string url= "/api/EtapaFenologica/GetAllEtapas";

        public GetAllEtapas(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("Admin")]
        [InlineData("User")]
        public async Task GetAllEtapaCorrectamente(string username)
        {
            const string pass = "123";
            var client = await GetAuthenticatedClientAsync(username, pass);
            var response=await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetEtapaFenologicaListResponse>(response);

            Assert.IsType<GetEtapaFenologicaListResponse>(result);
            Assert.True(result.EtapaFenologica.Count > 0);
        }

        [Theory]
        [InlineData("Visor")]
        [InlineData("Productor")]
        public async Task GetAllEtapasUnauthorized(string username)
        {
            const string pass = "123";
            var client = await GetAuthenticatedClientAsync(username, pass);
            var response = await client.GetAsync(url);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetAllEtapasAnonymousNotAutorized()
        {
            var client = GetClient();
            var response = await client.GetAsync(url);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
