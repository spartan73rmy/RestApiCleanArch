using System.Collections.Generic;

namespace RestApiCleanArch.Application.UseCases.Plagas.Queries.GetPlagas
{
    public class GetPlagasResponse
    {
        public IList<PlagaLookupModel> Plagas { get; set; }
    }

    public class PlagaLookupModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
