using RestApiCleanArch.Application.UseCases.Usuarios.Commands.CreateUsuario;
using RestApiCleanArch.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RestApiCleanArch.WebUi.FunctionalTests.Controllers.Customers
{
    public class Create : BaseTestController
    {
        public Create(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GivenCreateUsuarioCommand_ReturnsSuccessStatusCode()
        {
            var client = GetClient();
            var command = new CreateUsuarioCommand
            {
                Email = "asd2@asd.com",
                TipoUsuario = (int)Domain.Enums.TiposUsuario.Admin,
                NombreUsuario = "Adminstrador",
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
            Assert.Equal(command.Nombre, responseContent.Nombre);
            Assert.Equal(command.ApellidoPaterno, responseContent.ApellidoPaterno);
            Assert.Equal(command.ApellidoMaterno, responseContent.ApellidoMaterno);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task DadoUsuarioCreadoAnteriormente_RetornaBadRequest()
        {
            var client = GetClient();
            var command = new CreateUsuarioCommand
            {
                Email = "asd2@asd.com",
                TipoUsuario = (int)Domain.Enums.TiposUsuario.Admin,
                NombreUsuario = "Admin",
                Password = "123",
                Nombre = "Nombre",
                ApellidoMaterno = "Apellido materno",
                ApellidoPaterno = "Apellido paterno"
            };

            var content = Utilities.GetRequestContent(command);
            var response = await client.PostAsync($"/api/Cuenta/createuser", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task DadoEmailCreadoAnteriormente_RetornaBadRequest()
        {
            var client = GetClient();
            var command = new CreateUsuarioCommand
            {
                Email = "asd@asd.com",
                TipoUsuario = (int)Domain.Enums.TiposUsuario.Admin,
                NombreUsuario = "Admin2",
                Password = "123",
                Nombre = "Nombre",
                ApellidoMaterno = "Apellido materno",
                ApellidoPaterno = "Apellido paterno"
            };

            var content = Utilities.GetRequestContent(command);
            var response = await client.PostAsync($"/api/Cuenta/createuser", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("12")]
        [InlineData("Hola asd")]
        [InlineData(" Holafcxx")]
        [InlineData("Ho@lafcxx")]
        [InlineData("Ho/lafcxx")]
        public async Task DadoUserNameNoValidoRetornaBadRequest(string username)
        {
            var client = GetClient();
            var command = new CreateUsuarioCommand
            {
                Email = "asdasd@zasdadasd.qweasd",
                TipoUsuario = (int)RestApiCleanArch.Domain.Enums.TiposUsuario.Admin,
                NombreUsuario = username,
                Password = "123",
                Nombre = "Nombre",
                ApellidoMaterno = "Apellido materno",
                ApellidoPaterno = "Apellido paterno"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await client.PostAsync($"/api/Cuenta/createuser", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}