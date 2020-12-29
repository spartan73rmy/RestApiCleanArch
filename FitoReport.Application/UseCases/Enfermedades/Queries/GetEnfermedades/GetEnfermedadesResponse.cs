using System.Collections.Generic;

namespace FitoReport.Application.UseCases.Enfermedades.Queries.GetEnfermedades
{
    public class GetEnfermedadesResponse
    {
        public IList<EnfermedadLookupModel> Enfermedades { get; set; }
    }

    public class EnfermedadLookupModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
