using System.Collections.Generic;

namespace RestApiCleanArch.Domain.Entities
{
    public class Enfermedad : DeleteableEntity
    {
        public int IdReport { get; set; }
        public string Nombre { get; set; }
        public ICollection<ReporteEnfermedad> ReporteEnfermedad { get; set; }

    }
}