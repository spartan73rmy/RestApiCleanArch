using FitoReport.Application.UseCases.EtapasFenologicas.Commands.DeleteEtapaFenologica;
using FitoReport.Application.UseCases.EtapasFenologicas.Queries.GetEtapaFenologicaList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitoReport.WebUi.Controllers
{
    [ApiController]
    public class EtapaFenologicaController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetEtapaFenologicaListResponse>> GetAllEtapas()
        {
            return Ok(await Mediator.Send(new GetEtapaFenologicaListQuery()));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeleteEtapaFenologicaResponse>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteEtapaFenologicaCommand { IdEtapa = id }));
        }
    }
}