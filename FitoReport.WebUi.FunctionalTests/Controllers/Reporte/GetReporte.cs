using FitoReport.Application.UseCases.Reportes.Queries.GetReporte;
using FitoReport.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FitoReport.WebUi.FunctionalTests.Controllers.Reporte
{
    public class GetReporte : BaseTestController
    {
        public GetReporte(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("Admin")]
        [InlineData("User")]
        [InlineData("Visor")]
        [InlineData("Productor")]
        public async Task GetReporteCorrectamente(string username)
        {
            string pass = "123";
            var client = await GetAuthenticatedClientAsync(username, pass);
            var response = await client.GetAsync("/api/Reporte/Get/1");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetReporteResponse>(response);

            Assert.IsType<GetReporteResponse>(result);
            Assert.True(result.Plagas.Count > 0);
        }

        [Fact]
        public async Task GetReporteAnonymousNotAutorized()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/Reporte/Get/1");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
