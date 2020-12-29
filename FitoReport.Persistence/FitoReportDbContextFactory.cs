using FitoReport.Persistence.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace FitoReport.Persistence
{
    public class FitoReportDbContextFactory : DesignTimeDbContextFactoryBase<FitoReportDbContext>
    {
        protected override FitoReportDbContext CreateNewInstance(DbContextOptions<FitoReportDbContext> options)
        {
            return new FitoReportDbContext(options);
        }
    }
}
