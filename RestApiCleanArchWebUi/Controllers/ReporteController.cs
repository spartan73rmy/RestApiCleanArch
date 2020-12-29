using RestApiCleanArch.Application.UseCases.Reportes.Commands.AgregarReporte;
using RestApiCleanArch.Application.UseCases.Reportes.Queries.GetReporte;
using RestApiCleanArch.Application.UseCases.Reportes.Queries.GetSearchReportList;
using RestApiCleanArch.WebUi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RestApiCleanArchCab.WebUi.Controllers
{
    [ApiController]
    public class ReporteController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<AgregarReporteResponse>> Agregar([FromBody] AgregarReporteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{idReport}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetReporteResponse>> Get(int idReport)
        {
            return Ok(await Mediator.Send(new GetReporteQuery { IdReporte = idReport }));
        }

        [HttpGet]
        public async Task<ActionResult<GetSearchReportListResponse>> GetSearchList()
        {
            return Ok(await Mediator.Send(new GetSearchReportListQuery()));
        }
    }
}