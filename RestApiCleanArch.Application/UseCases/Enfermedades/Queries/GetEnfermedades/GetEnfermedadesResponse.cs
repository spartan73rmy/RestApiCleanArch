using System.Collections.Generic;

namespace RestApiCleanArch.Application.UseCases.Enfermedades.Queries.GetEnfermedades
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
