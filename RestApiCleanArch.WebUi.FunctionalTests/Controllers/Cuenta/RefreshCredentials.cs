using RestApiCleanArch.Application.UseCases.Usuarios.Commands.RefreshCredentials;
using RestApiCleanArch.Application.UseCases.Usuarios.Queries.GetUsuarioLogin;
using RestApiCleanArch.WebUi.FunctionalTests.Common;
using System.Threading.Tasks;
using Xunit;
using static RestApiCleanArch.WebUi.Controllers.CuentaController;

namespace RestApiCleanArch.WebUi.FunctionalTests.Controllers.Cuenta
{
    public class RefreshCredentials : BaseTestController
    {
        public RefreshCredentials(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task SeLogueaYActualizaTokenCorrectamente()
        {
            var client = GetClient();
            var loginCommand = new GetUsuarioLoginQuery
            {
                NombreUsuario = "User",
                Password = "123"
            };

            var contentLogin = Utilities.GetRequestContent(loginCommand);
            var response = await client.PostAsync($"/api/Cuenta/Ingresar", contentLogin);

            response.EnsureSuccessStatusCode();

            var responseContent = await Utilities.GetResponseContent<IngresarResponse>(response);

            Assert.NotNull(responseContent.Token);
            Assert.NotNull(responseContent.User);
            Assert.NotNull(responseContent.User.RefreshToken);

            var refreshCommand = new RefreshCredentialsCommand
            {
                RefreshToken = responseContent.User.RefreshToken,
                Token = responseContent.Token
            };

            var contentRefresh = Utilities.GetRequestContent(refreshCommand);
            var responseRefresh = await client.PostAsync($"/api/Cuenta/RefreshCredentials", contentRefresh);

            responseRefresh.EnsureSuccessStatusCode();

            var responseR = await Utilities.GetResponseContent<IngresarResponse>(response);

            Assert.NotNull(responseR.Token);
            Assert.NotNull(responseR.User);
            Assert.NotNull(responseR.User.RefreshToken);
        }
    }
}