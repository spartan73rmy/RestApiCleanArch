using RestApiCleanArch.Common;
using MediatR;
using System;
using System.Collections.Generic;

namespace RestApiCleanArch.Application.UseCases.Reportes.Commands.AgregarReporte
{
    public class AgregarReporteCommand : IRequest<AgregarReporteResponse>
    {
        public List<ReporteDTO> Reportes { get; set; }
        public class ReporteDTO
        {
            public int Id { get; set; }
            public string Lugar { get; set; }
            public string Productor { get; set; }
            public double Latitude { get; set; }
            public double Longitud { get; set; }
            public string Ubicacion { get; set; }
            public string Predio { get; set; }
            public string Cultivo { get; set; }
            public string Observaciones { get; set; }
            public int Litros { get; set; }
            public DateTime Created { get; set; }
            public virtual ICollection<EtapaFenogolicaDTO> EtapaFenologica { get; set; }
            public virtual ICollection<EnfermedadDTO> Enfermedades { get; set; }
            public virtual ICollection<PlagaDTO> Plagas { get; set; }
            public virtual ICollection<ProductoDTO> Productos { get; set; }

            public class ProductoDTO
            {
                public double Cantidad { get; set; }
                public string Unidad { get; set; }
                public string Nombre { get; set; }
                public string IngredienteActivo { get; set; }
                public string Concentracion { get; set; }
                public string IntervaloSeguridad { get; set; }
            }
            public class PlagaDTO
            {
                public int Id { get; set; }
                public string Nombre { get; set; }
            }
            public class EnfermedadDTO
            {
                public int Id { get; set; }
                public string Nombre { get; set; }
            }
            public class EtapaFenogolicaDTO
            {
                public int Id { get; set; }
                public string Nombre { get; set; }
            }
        }
    }
}