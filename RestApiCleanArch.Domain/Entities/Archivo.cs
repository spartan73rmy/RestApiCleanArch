namespace RestApiCleanArch.Domain.Entities
{
    public partial class Archivo : BaseEntity
    {
        public Archivo()
        {
        }

        public int IdReporte { get; set; }
        public int IdUsuario { get; set; }
        public string Hash { get; set; }
        public string ContentType { get; set; }
        public string Nombre { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Reporte IdReporteNavigation { get; set; }
    }
}
