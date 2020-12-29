using System.Collections.Generic;

namespace RestApiCleanArch.Domain.Entities
{
    public class Reporte : BaseEntity
    {
        public Reporte()
        {
            Productos = new HashSet<Producto>();
            ReporteEnfermedad = new HashSet<ReporteEnfermedad>();
            ReporteEtapaFenologica = new HashSet<ReporteEtapaFenologica>();
            ReportePlaga = new HashSet<ReportePlaga>();
        }

        public string Lugar { get; set; }
        public string Productor { get; set; }
        public double Latitude { get; set; }
        public double Longitud { get; set; }
        public string Ubicacion { get; set; }
        public string Predio { get; set; }
        public string Cultivo { get; set; }
        public string Observaciones { get; set; }
        public int Litros { get; set; }
        public virtual ICollection<ReporteEnfermedad> ReporteEnfermedad { get; set; }
        public virtual ICollection<ReporteEtapaFenologica> ReporteEtapaFenologica { get; set; }
        public virtual ICollection<ReportePlaga> ReportePlaga { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Archivo> Archivos { get; set; }

    }
}
