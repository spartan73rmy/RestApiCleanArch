using RestApiCleanArch.Application.UseCases.Usuarios.Commands.ModificarDatosUsuario;
using RestApiCleanArch.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RestApiCleanArch.WebUi.FunctionalTests.Controllers.Usuarios
{
    public class ModificarDatos : BaseTestController
    {
        public ModificarDatos(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ModificaCorrectamenteAdmin()
        {
            var client = await GetAdminClientAsync();
            var pet = new ModificarDatosUsuarioCommand
            {
                IdUsuario = 1,
                Nombre = "Javier",
                ApellidoPaterno = "Mendez",
                ApellidoMaterno = "Rodriguez"
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PutAsync("/api/Usuarios/ModificarDatos", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<ModificarDatosUsuarioResponse>(response);

            Assert.IsType<ModificarDatosUsuarioResponse>(result);
            Assert.Equal(pet.Nombre, result.Nombre);
            Assert.Equal(pet.ApellidoPaterno, result.ApellidoPaterno);
            Assert.Equal(pet.ApellidoMaterno, result.ApellidoMaterno);
            Assert.True(result.IdUsuario > 0);
        }

        [Fact]
        public async Task BadRequestPorNombreVacio()
        {
            var client = await GetVisorClientAsync();
            var pet = new ModificarDatosUsuarioCommand
            {
                IdUsuario = 1,
                Nombre = "",
                ApellidoPaterno = "Mendez",
                ApellidoMaterno = "Rodriguez"
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PutAsync("/api/Usuarios/ModificarDatos", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}