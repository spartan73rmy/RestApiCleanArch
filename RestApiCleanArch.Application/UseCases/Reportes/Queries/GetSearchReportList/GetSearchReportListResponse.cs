using System;
using System.Collections.Generic;

namespace RestApiCleanArch.Application.UseCases.Reportes.Queries.GetSearchReportList
{
    public class GetSearchReportListResponse
    {

        public List<DataSearch> Busqueda { get; set; }
        public class DataSearch
        {
            public int IdReport { get; set; }
            public string Productor { get; set; }
            public string Lugar { get; set; }
            public string Predio { get; set; }
            public string Ubicacion { get; set; }
            public DateTime Fecha { get; set; }
        }
    }
}
