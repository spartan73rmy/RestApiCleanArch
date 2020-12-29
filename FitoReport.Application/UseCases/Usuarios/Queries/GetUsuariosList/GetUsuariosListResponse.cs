using System.Collections.Generic;

namespace FitoReport.Application.UseCases.Usuarios.Queries.GetUsuariosList
{
    public class GetUsuariosListResponse
    {
        public IList<UsuarioLookupModel> Usuarios { get; set; }
    }
}