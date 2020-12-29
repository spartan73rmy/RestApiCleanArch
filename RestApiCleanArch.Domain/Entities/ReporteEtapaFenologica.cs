namespace RestApiCleanArch.Domain.Entities
{
    public class ReporteEtapaFenologica : BaseEntity
    {
        public int IdReporte { get; set; }
        public int IdEtapaFenologica { get; set; }
        public virtual EtapaFenologica EtapaFenologica { get; set; }
        public virtual Reporte Reporte { get; set; }
    }
}