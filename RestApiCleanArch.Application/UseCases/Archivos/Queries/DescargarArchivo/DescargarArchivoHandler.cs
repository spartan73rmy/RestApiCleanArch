using RestApiCleanArch.Application.Exceptions;
using RestApiCleanArch.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Archivos.Queries.DescargarArchivo
{
    public class DescargarArchivoHandler : IRequestHandler<DescargarArchivoQuery, DescargarArchivoResponse>
    {
        private readonly IRestApiCleanArchDbContext db;
        private readonly IFileService fileService;

        public DescargarArchivoHandler(IRestApiCleanArchDbContext db, IFileService fileService)
        {
            this.db = db;
            this.fileService = fileService;
        }

        public async Task<DescargarArchivoResponse> Handle(DescargarArchivoQuery request, CancellationToken cancellationToken)
        {
            var token = await db
                .TokenDescargaArchivo
                .SingleOrDefaultAsync(el => el.Token == request.TokenDescarga && el.HashArchivo == request.Hash);

            if (token == null)
                throw new NotAuthorizedException("No autorizado");

            db.TokenDescargaArchivo.Remove(token);
            await db.SaveChangesAsync(cancellationToken);

            bool fileExists = await db.ArchivoUsuario.AnyAsync(el => el.Hash == request.Hash);

            if (!fileExists)
                throw new NotFoundException("Archivo", request.Hash);

            var file = await db
                .ArchivoUsuario
                .SingleOrDefaultAsync(el => el.Hash == request.Hash);

            var stream = fileService.GetStreamFile(request.Hash);

            return new DescargarArchivoResponse
            {
                Archivo = stream,
                ContentType = file.ContentType,
                Nombre = file.Nombre
            };
        }
    }
}