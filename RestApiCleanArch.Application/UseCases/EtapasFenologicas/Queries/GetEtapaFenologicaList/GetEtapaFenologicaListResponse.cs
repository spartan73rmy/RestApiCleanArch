using System.Collections.Generic;

namespace RestApiCleanArch.Application.UseCases.EtapasFenologicas.Queries.GetEtapaFenologicaList
{
    public class GetEtapaFenologicaListResponse
    {
        public List<EtapaLookUpModel> EtapaFenologica { get; set; }

    }
    public class EtapaLookUpModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
