using RestApiCleanArch.Application.UseCases.Plagas.Commands.DeletePlaga;
using RestApiCleanArch.Application.UseCases.Plagas.Queries.GetPlagas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RestApiCleanArch.WebUi.Controllers
{
    [ApiController]
    public class PlagaController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetPlagasResponse>> GetPlagas()
        {
            return Ok(await Mediator.Send(new GetPlagasQuery()));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeletePlagaResponse>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePlagaCommand { IdPlaga = id }));
        }
    }
}