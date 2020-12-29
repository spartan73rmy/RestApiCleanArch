using FitoReport.Application.UseCases.Enfermedades.Commands.DeleteEnfermedad;
using FitoReport.Application.UseCases.Enfermedades.Queries.GetEnfermedades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitoReport.WebUi.Controllers
{
    [ApiController]
    public class EnfermedadController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetEnfermedadesResponse>> GetEnfermedades()
        {
            return Ok(await Mediator.Send(new GetEnfermedadesQuery()));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeleteEnfermedadResponse>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteEnfermedadCommand { IdEnferemedad = id }));
        }
    }
}