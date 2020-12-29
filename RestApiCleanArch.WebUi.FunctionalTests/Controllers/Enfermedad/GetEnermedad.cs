using RestApiCleanArch.Application.UseCases.Enfermedades.Queries.GetEnfermedades;
using RestApiCleanArch.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RestApiCleanArch.WebUi.FunctionalTests.Controllers.Enfermedad
{
    public class GetEnermedad : BaseTestController
    {
        public GetEnermedad(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("Admin")]
        [InlineData("User")]
        public async Task GetEnfermedadCorrectamente(string username)
        {
            string pass = "123";
            var client = await GetAuthenticatedClientAsync(username,pass);
            var response = await client.GetAsync("/api/Enfermedad/GetEnfermedades");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetEnfermedadesResponse>(response);

            Assert.IsType<GetEnfermedadesResponse>(result);
            Assert.True(result.Enfermedades.Count > 0);
        }

        [Theory]
        [InlineData("Visor")]
        [InlineData("Productor")]
        public async Task GetEnfermedadNotAutorized(string username)
        {
            string pass = "123";
            var client = await GetAuthenticatedClientAsync(username, pass);
            var response = await client.GetAsync("/api/Enfermedad/GetEnfermedades");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetAnonymousNotAutorized()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/Enfermedad/GetEnfermedades");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
