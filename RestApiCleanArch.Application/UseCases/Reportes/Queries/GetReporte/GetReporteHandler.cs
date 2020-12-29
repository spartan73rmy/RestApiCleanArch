using RestApiCleanArch.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static RestApiCleanArch.Application.UseCases.Reportes.Queries.GetReporte.GetReporteResponse;

namespace RestApiCleanArch.Application.UseCases.Reportes.Queries.GetReporte
{
    public class GetReporteHandler : IRequestHandler<GetReporteQuery, GetReporteResponse>
    {
        private readonly IRestApiCleanArchDbContext db;

        public GetReporteHandler(IRestApiCleanArchDbContext db)
        {
            this.db = db;
        }

        public async Task<GetReporteResponse> Handle(GetReporteQuery query, CancellationToken cancellationToken)
        {
            var entity = await db
                .Reporte
                .Where(m => m.Id == query.IdReporte)
                .Select(request => new GetReporteResponse
                {
                    IdReport = request.Id,
                    Lugar = request.Lugar,
                    Created = request.Created,
                    Productor = request.Productor,
                    Latitude = request.Latitude,
                    Longitud = request.Longitud,
                    Ubicacion = request.Ubicacion,
                    Predio = request.Predio,
                    Cultivo = request.Cultivo,
                    Observaciones = request.Observaciones,
                    Litros = request.Litros,
                    EtapaFenologica = request.ReporteEtapaFenologica.Where(el => el.IdReporte == query.IdReporte).Select(el => new EtapaFenogolicaDTO()
                    {
                        Id = el.EtapaFenologica.Id,
                        Nombre = el.EtapaFenologica.Nombre,
                    }).ToList() ?? new List<EtapaFenogolicaDTO>(),
                    Enfermedades = request.ReporteEnfermedad.Where(el => el.IdReporte == query.IdReporte).Select(el => new EnfermedadDTO()
                    {
                        Id = el.Enfermedad.Id,
                        Nombre = el.Enfermedad.Nombre,
                    }).ToList() ?? new List<EnfermedadDTO>(),
                    Plagas = request.ReportePlaga.Where(el => el.IdReporte == query.IdReporte).Select(el => new PlagaDTO
                    {
                        Id = el.Plaga.Id,
                        Nombre = el.Plaga.Nombre,
                    }).ToList() ?? new List<PlagaDTO>(),
                    Productos = request.Productos.Select(el => new ProductoDTO
                    {
                        Nombre = el.NombreProducto,
                        Cantidad = el.Cantidad,
                        Concentracion = el.Concentracion,
                        IngredienteActivo = el.IngredienteActivo,
                        IntervaloSeguridad = el.IntervaloSeguridad
                    }).ToList() ?? new List<ProductoDTO>(),
                }).FirstOrDefaultAsync(cancellationToken);

            return entity;
        }
    }
}