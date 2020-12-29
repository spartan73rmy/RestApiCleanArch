namespace RestApiCleanArch.Domain.Entities
{
    public class ReporteEnfermedad : BaseEntity
    {
        public int IdReporte { get; set; }
        public int IdEnfermedad { get; set; }
        public virtual Enfermedad Enfermedad { get; set; }
        public virtual Reporte Reporte { get; set; }
    }
}
