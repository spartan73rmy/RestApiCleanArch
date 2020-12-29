using RestApiCleanArch.Application.UseCases.Usuarios.Commands.CreateUsuario;
using RestApiCleanArch.Application.UseCases.Usuarios.Queries.GetUsuarioLogin;
using RestApiCleanArch.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using static RestApiCleanArch.WebUi.Controllers.CuentaController;

namespace RestApiCleanArch.WebUi.FunctionalTests.Controllers.Cuenta
{
    public class Login : BaseTestController
    {
        public Login(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task CreaUsuarioEIntentaLoginSinConfirmarEmail()
        {
            var client = GetClient();
            var command = new CreateUsuarioCommand
            {
                Email = "asd2zc@asd.com",
                TipoUsuario = (int)RestApiCleanArch.Domain.Enums.TiposUsuario.Admin,
                NombreUsuario = "admin2987",
                Password = "123",
                Nombre = "Nombre",
                ApellidoMaterno = "Apellido materno",
                ApellidoPaterno = "Apellido paterno"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await client.PostAsync($"/api/Cuenta/createuser", content);

            var responseContent = await Utilities.GetResponseContent<CreateUsuarioResponse>(response);

            Assert.Equal(command.Email, responseContent.Email);
            Assert.Equal(command.NombreUsuario, responseContent.NombreUsuario);

            response.EnsureSuccessStatusCode();

            var loginCommand = new GetUsuarioLoginQuery
            {
                NombreUsuario = "admin2987",
                Password = "123"
            };

            var contentLogin = Utilities.GetRequestContent(loginCommand);
            var responseLogin = await client.PostAsync($"/api/Cuenta/ingresar", contentLogin);

            Assert.Equal(HttpStatusCode.Forbidden, responseLogin.StatusCode);
        }

        [Fact]
        public async Task SeLogueaCorrectamente()
        {
            var client = GetClient();
            var loginCommand = new GetUsuarioLoginQuery
            {
                NombreUsuario = "Admin",
                Password = "123"
            };

            var contentLogin = Utilities.GetRequestContent(loginCommand);
            var response = await client.PostAsync($"/api/Cuenta/ingresar", contentLogin);

            response.EnsureSuccessStatusCode();

            var responseContent = await Utilities.GetResponseContent<IngresarResponse>(response);

            Assert.NotNull(responseContent.Token);
            Assert.NotNull(responseContent.User);
            Assert.NotNull(responseContent.User.RefreshToken);
        }

        [Fact]
        public async Task DespuesDe5IntentosIncorrectosLaCuentaSeBloquea()
        {
            var client = GetClient();
            var loginCommand = new GetUsuarioLoginQuery
            {
                NombreUsuario = "Admin",
                Password = "1234"
            };

            var contentLogin = Utilities.GetRequestContent(loginCommand);

            for (int i = 0; i < 5; i++)
            {
                var resp = await client.PostAsync($"/api/Cuenta/ingresar", contentLogin);

                Assert.Equal(HttpStatusCode.NotFound, resp.StatusCode);
            }

            var response = await client.PostAsync($"/api/Cuenta/ingresar", contentLogin);

            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }
    }
}