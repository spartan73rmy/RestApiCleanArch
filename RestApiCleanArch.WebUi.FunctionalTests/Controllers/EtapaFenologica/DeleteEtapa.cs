using RestApiCleanArch.Application.UseCases.EtapasFenologicas.Commands.DeleteEtapaFenologica;
using RestApiCleanArch.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RestApiCleanArch.WebUi.FunctionalTests.Controllers.EtapaFenologica
{
    public class DeleteEtapa : BaseTestController
    {
        private readonly string url = "/api/EtapaFenologica/Delete/";
        public DeleteEtapa(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("User", 1)]
        [InlineData("Admin", 2)]
        public async Task EliminaCorrectamenteEtapa(string username, int id)
        {
            string pass = "123";
            var client = await GetAuthenticatedClientAsync(username, pass);

            var response = await client.DeleteAsync(url + id); ;

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<DeleteEtapaFenologicaResponse>(response);

            Assert.IsType<DeleteEtapaFenologicaResponse>(result);
        }

        [Theory]
        [InlineData("Visor")]
        [InlineData("Productor")]
        public async Task EliminarEtapaRetornaNotAuthorized(string username)
        {
            string pass = "123";
            var client = await GetAuthenticatedClientAsync(username, pass);
            var response = await client.DeleteAsync(url + "1"); ;

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task EliminarEtapaRepornaNotFound()
        {
            var client = await GetAdminClientAsync();
            var response = await client.DeleteAsync(url + "777");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
