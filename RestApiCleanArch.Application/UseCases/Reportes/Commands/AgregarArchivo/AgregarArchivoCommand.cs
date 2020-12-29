using MediatR;

namespace RestApiCleanArch.Application.UseCases.Reportes.Commands.AgregarArchivo
{
    public class AgregarArchivoCommand : IRequest<AgregarArchivoResponse>
    {
        public string Archivo { get; set; }
        public int IdActividad { get; set; }
    }
}