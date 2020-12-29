using RestApiCleanArch.Application.UseCases.Archivos.Commands.AgregarArchivo;
using RestApiCleanArch.Application.UseCases.Archivos.Queries.DescargarArchivo;
using RestApiCleanArch.Application.UseCases.Archivos.Queries.TokenDescarga;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RestApiCleanArch.WebUi.Controllers
{
    public class ArchivosController : BaseController
    {
        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<AgregarArchivoResponse>> AgregarArchivo([FromForm] IFormFile file)
        {
            System.Console.WriteLine(file.ContentType);
            using (var fileStream = file.OpenReadStream())
            {
                var result = await Mediator.Send(new AgregarArchivoCommand
                {
                    Archivo = fileStream,
                    ContentType = file.ContentType,
                    Nombre = file.FileName
                });
                return Ok(result);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TokenDescargaResponse>> GeneraTokenDescarga(TokenDescargaQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{hash}")]
        [AllowAnonymous]
        public async Task<FileResult> DescargarArchivo(string hash, string token)
        {
            var file = await Mediator.Send(new DescargarArchivoQuery { Hash = hash, TokenDescarga = token });
            return File(file.Archivo, file.ContentType, file.Nombre);
        }
    }
}