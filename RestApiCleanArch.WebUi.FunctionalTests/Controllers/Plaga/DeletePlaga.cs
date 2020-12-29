using RestApiCleanArch.Application.UseCases.Plagas.Commands.DeletePlaga;
using RestApiCleanArch.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RestApiCleanArch.WebUi.FunctionalTests.Controllers.Plaga
{
    public class DeletePlaga : BaseTestController
    {
        public DeletePlaga(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Theory]
        [InlineData("User", 1)]
        [InlineData("Admin", 2)]
        public async Task EliminaCorrectamentePlaga(string username, int id)
        {
            string pass = "123";
            var client = await GetAuthenticatedClientAsync(username, pass);

            var response = await client.DeleteAsync("/api/Plaga/Delete/" + id);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<DeletePlagaResponse>(response);

            Assert.IsType<DeletePlagaResponse>(result);
        }

        [Theory]
        [InlineData("Visor")]
        [InlineData("Productor")]
        public async Task EliminarPlagaRetornaNotAuthorized(string username)
        {
            string pass = "123";
            var client = await GetAuthenticatedClientAsync(username, pass);
            var response = await client.DeleteAsync("/api/Plaga/Delete/1");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task EliminarPlagaRepornaNotFound()
        {
            var client = await GetAdminClientAsync();
            var response = await client.DeleteAsync("/api/Plaga/Delete/777");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
