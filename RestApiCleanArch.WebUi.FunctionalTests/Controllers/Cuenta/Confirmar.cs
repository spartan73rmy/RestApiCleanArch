using RestApiCleanArch.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RestApiCleanArch.WebUi.FunctionalTests.Controllers.Cuenta
{
    public class Confirmar : BaseTestController
    {
        public Confirmar(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ConfirmarUsuarioCorrectamente()
        {
            var client = GetClient();
            var response = await client.GetAsync($"/api/Cuenta/Confirmar?Token=123");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task ConfirmarUsuarioNoAutorizado()
        {
            var client = GetClient();
            var response = await client.GetAsync($"/api/Cuenta/Confirmar?Token=12345");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}