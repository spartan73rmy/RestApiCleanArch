using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static RestApiCleanArch.Application.UseCases.Reportes.Commands.AgregarReporte.AgregarReporteCommand;
using static RestApiCleanArch.Application.UseCases.Reportes.Commands.AgregarReporte.AgregarReporteCommand.ReporteDTO;

namespace RestApiCleanArch.Application.UseCases.Reportes.Commands.AgregarReporte
{
    public class AgregarReporteHandler : IRequestHandler<AgregarReporteCommand, AgregarReporteResponse>
    {
        private readonly IRestApiCleanArchDbContext db;

        public AgregarReporteHandler(IRestApiCleanArchDbContext db)
        {
            this.db = db;
        }

        public async Task<AgregarReporteResponse> Handle(AgregarReporteCommand request, CancellationToken cancellationToken)
        {

            foreach (ReporteDTO item in request.Reportes)
            {
                Reporte entity = new Reporte
                {
                    Lugar = item.Lugar,
                    Productor = item.Productor,
                    Latitude = item.Latitude,
                    Longitud = item.Longitud,
                    Ubicacion = item.Ubicacion,
                    Predio = item.Predio,
                    Cultivo = item.Cultivo,
                    Observaciones = item.Observaciones,
                    Litros = item.Litros,
                };

                db.Reporte.Add(entity);
                foreach (ProductoDTO p in item.Productos)
                {
                    entity.Productos.Add(new Producto
                    {
                        IdReport = entity.Id,
                        Cantidad = p.Cantidad,
                        Unidad = p.Unidad,
                        Concentracion = p.Concentracion,
                        IngredienteActivo = p.IngredienteActivo,
                        IntervaloSeguridad = p.IntervaloSeguridad,
                        NombreProducto = p.Nombre,
                        Reporte = entity
                    });
                }

                foreach (PlagaDTO plaga in item.Plagas)
                {
                    //Search if exist a Plaga with equals or similar name
                    string nombre = NormalizeString(plaga.Nombre);

                    Plaga oldPlaga = await
                        db.Plaga.Where(el =>
                        el.Nombre.Replace(" ", "").ToLower().Equals(nombre))
                        .FirstOrDefaultAsync();

                    if (oldPlaga == null)
                    {
                        Plaga newPlaga = new Plaga
                        {
                            Nombre = plaga.Nombre
                        };
                        db.Plaga.Add(newPlaga);
                        await db.SaveChangesAsync(cancellationToken);

                        entity.ReportePlaga.Add(new ReportePlaga { Plaga = newPlaga });
                    }
                    else
                    {
                        oldPlaga.IsDeleted = false;
                        oldPlaga.DeletedDate = null;
                        db.Plaga.Update(oldPlaga);
                        entity.ReportePlaga.Add(new ReportePlaga { Plaga = oldPlaga });
                    }
                }

                foreach (EtapaFenogolicaDTO etapa in item.EtapaFenologica)
                {
                    //Search if exist a Etapa with equals or similar name
                    string nombre = NormalizeString(etapa.Nombre);

                    EtapaFenologica oldEtapaF = await
                        db.EtapaFenologica.Where(el =>
                        el.Nombre.Replace(" ", "").ToLower().Equals(nombre))
                        .FirstOrDefaultAsync();

                    if (oldEtapaF == null)
                    {
                        var newEtapa = new EtapaFenologica
                        {
                            Nombre = etapa.Nombre
                        };
                        db.EtapaFenologica.Add(newEtapa);
                        await db.SaveChangesAsync(cancellationToken);

                        entity.ReporteEtapaFenologica.Add(new ReporteEtapaFenologica { EtapaFenologica = newEtapa });
                    }
                    else
                    {
                        oldEtapaF.IsDeleted = false;
                        oldEtapaF.DeletedDate = null;
                        db.EtapaFenologica.Update(oldEtapaF);
                        entity.ReporteEtapaFenologica.Add(new ReporteEtapaFenologica { EtapaFenologica = oldEtapaF });
                    }
                }

                foreach (EnfermedadDTO enfermedad in item.Enfermedades)
                {
                    //Search if exist a Enfermedad with equals or similar name
                    string nombre = NormalizeString(enfermedad.Nombre);

                    Enfermedad oldEnfermedad = await
                        db.Enfermedad.Where(el =>
                        el.Nombre.Replace(" ", "").ToLower().Equals(nombre))
                        .FirstOrDefaultAsync();

                    if (oldEnfermedad == null)
                    {
                        Enfermedad newEnfermedad = new Enfermedad
                        {
                            Nombre = enfermedad.Nombre
                        };
                        db.Enfermedad.Add(newEnfermedad);
                        await db.SaveChangesAsync(cancellationToken);

                        entity.ReporteEnfermedad.Add(new ReporteEnfermedad { Enfermedad = newEnfermedad });
                    }
                    else
                    {
                        oldEnfermedad.IsDeleted = false;
                        oldEnfermedad.DeletedDate = null;
                        db.Enfermedad.Update(oldEnfermedad);
                        entity.ReporteEnfermedad.Add(new ReporteEnfermedad { Enfermedad = oldEnfermedad });
                    }
                }
            }

            await db.SaveChangesAsync(cancellationToken);

            return new AgregarReporteResponse
            {
                Id = 0,
            };
        }

        private string NormalizeString(string toNormalize)
        {
            return NormalizeString(new[] { " ", ".", "," }, toNormalize);
        }
        private string NormalizeString(string[] charsToDelete, string toNormalize)
        {
            foreach (string item in charsToDelete)
            {
                toNormalize = toNormalize.Replace(
                   item, newValue: string.Empty);
            }
            return toNormalize.ToLower();
        }
    }
}