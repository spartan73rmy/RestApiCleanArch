using RestApiCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.Interfaces
{
    public interface IRestApiCleanArchDbContext
    {
        DbSet<Reporte> Reporte { get; set; }
        DbSet<Archivo> ArchivoUsuario { get; set; }
        DbSet<Usuario> Usuario { get; set; }
        DbSet<UsuarioToken> UsuarioToken { get; set; }
        DbSet<TokenDescargaArchivo> TokenDescargaArchivo { get; set; }
        DbSet<Plaga> Plaga { get; set; }
        DbSet<Enfermedad> Enfermedad { get; set; }
        DbSet<Producto> Producto { get; set; }
        DbSet<EtapaFenologica> EtapaFenologica { get; set; }
        DbSet<ReporteEnfermedad> ReporteEnfermedad { get; set; }
        DbSet<ReportePlaga> ReportePlaga { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    }
}
