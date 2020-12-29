using RestApiCleanArch.Application.UseCases.Usuarios.Commands.ModificarEmail;
using RestApiCleanArch.WebUi.FunctionalTests.Common;
using System.Threading.Tasks;
using Xunit;

namespace RestApiCleanArch.WebUi.FunctionalTests.Controllers.Usuarios
{
    public class ModificarEmail : BaseTestController
    {
        public ModificarEmail(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("Visor", "alumnocambio@asd.com")]
        [InlineData("User", "maestrocambio@asd.com")]
        [InlineData("Admin", "adminewemail@asd.com")]
        public async Task ReturnsSuccessStatusCode(string username, string email)
        {
            string pass = "123";
            var client = await GetAuthenticatedClientAsync(username, pass);
            var command = new ModificarEmailCommand
            {
                NuevoEmail = email,
                Password = pass
            };

            var content = Utilities.GetRequestContent(command);
            var response = await client.PostAsync($"/api/Usuarios/ModificarEmail", content);

            var responseContent = await Utilities.GetResponseContent<ModificarEmailResponse>(response);

            Assert.IsType<ModificarEmailResponse>(responseContent);
            Assert.Equal(command.NuevoEmail, responseContent.Email);

            response.EnsureSuccessStatusCode();
        }
    }
}