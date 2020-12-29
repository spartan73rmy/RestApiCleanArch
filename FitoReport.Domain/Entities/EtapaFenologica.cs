using System.Collections.Generic;

namespace FitoReport.Domain.Entities
{
    public class EtapaFenologica : DeleteableEntity
    {
        public int IdReport { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<ReporteEtapaFenologica> ReporteEtapaFenologica { get; set; }
    }
}
