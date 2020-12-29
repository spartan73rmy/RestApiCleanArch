using RestApiCleanArch.Application.UseCases.Usuarios.Commands.ReenviarEmail;
using RestApiCleanArch.WebUi.FunctionalTests.Common;
using System.Threading.Tasks;
using Xunit;

namespace RestApiCleanArch.WebUi.FunctionalTests.Controllers.Cuenta
{
    public class Reenviar : BaseTestController
    {
        public Reenviar(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ReturnsSuccessStatusCode()
        {
            var client = GetClient();
            var command = new ReenviarEmailCommand
            {
                Email = "usuarioasasdadad@aasdassd2.com"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await client.PostAsync($"/api/Cuenta/Reenviar", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await Utilities.GetResponseContent<ReenviarEmailResponse>(response);

            Assert.IsType<ReenviarEmailResponse>(responseContent);
            Assert.Equal(command.Email, responseContent.Email);

        }
    }
}