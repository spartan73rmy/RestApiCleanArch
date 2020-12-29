using RestApiCleanArch.Application.UseCases.Enfermedades.Commands.DeleteEnfermedad;
using RestApiCleanArch.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RestApiCleanArch.WebUi.FunctionalTests.Controllers.Enfermedad
{
    public class DeleteEnfermedad : BaseTestController
    {
        public DeleteEnfermedad(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Theory]
        [InlineData("User", 1)]
        [InlineData("Admin", 2)]
        public async Task EliminaCorrectamentePlaga(string username, int id)
        {
            string pass = "123";
            var client = await GetAuthenticatedClientAsync(username, pass);

            var response = await client.DeleteAsync("/api/Enfermedad/Delete/" + id);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<DeleteEnfermedadResponse>(response);

            Assert.IsType<DeleteEnfermedadResponse>(result);
        }

        [Theory]
        [InlineData("Visor")]
        [InlineData("Productor")]
        public async Task EliminarPlagaRetornaNotAuthorized(string username)
        {
            string pass = "123";
            var client = await GetAuthenticatedClientAsync(username, pass);
            var response = await client.DeleteAsync("/api/Enfermedad/Delete/1");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task EliminarPlagaRepornaNotFound()
        {
            var client = await GetAdminClientAsync();
            var response = await client.DeleteAsync("/api/Enfermedad/Delete/777");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
