using FitoReport.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Reportes.Queries.GetSearchReportList
{
    public class GetSearchReportListHandler : IRequestHandler<GetSearchReportListQuery, GetSearchReportListResponse>
    {
        private readonly IFitoReportDbContext db;

        public GetSearchReportListHandler(IFitoReportDbContext db)
        {
            this.db = db;
        }

        public async Task<GetSearchReportListResponse> Handle(GetSearchReportListQuery request, CancellationToken cancellationToken)
        {
            var busqueda = await db.Reporte.Select(el => new GetSearchReportListResponse.DataSearch
            {
                IdReport = el.Id,
                Productor = el.Productor,
                Predio = el.Predio,
                Lugar = el.Lugar,
                Ubicacion = el.Ubicacion,
                Fecha = el.Created
            }).OrderByDescending(f => f.Fecha).ToListAsync(cancellationToken);

            return new GetSearchReportListResponse { Busqueda = busqueda };
        }
    }
}
