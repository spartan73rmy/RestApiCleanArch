using RestApiCleanArch.Application.UseCases.Usuarios.Queries.GetUsuarioDetail;
using RestApiCleanArch.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RestApiCleanArch.WebUi.FunctionalTests.Controllers.Usuarios
{
    public class Get : BaseTestController
    {
        public Get(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ObtieneUsuarioCorrectamente()
        {
            var client = await GetVisorClientAsync();
            var response = await client.GetAsync("/api/Usuarios/Get/1");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetUsuarioDetailResponse>(response);

            Assert.IsType<GetUsuarioDetailResponse>(result);
            Assert.NotEmpty(result.Email);
            Assert.NotEmpty(result.NombreUsuario);
            Assert.True(result.IdUsuario > 0);
        }

        [Fact]
        public async Task ObtieneUsuarioNotAutorized()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/Usuarios/Get/1");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}