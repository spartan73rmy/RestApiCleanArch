namespace RestApiCleanArch.Domain.Entities
{
    public class ReportePlaga : BaseEntity
    {
        public int IdReporte { get; set; }
        public int IdPlaga { get; set; }
        public virtual Plaga Plaga { get; set; }
        public virtual Reporte Reporte { get; set; }

    }
}
