using MediatR;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarArchivo
{
    public class AgregarArchivoCommand : IRequest<AgregarArchivoResponse>
    {
        public string Archivo { get; set; }
        public int IdActividad { get; set; }
    }
}