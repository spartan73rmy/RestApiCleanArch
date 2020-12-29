using RestApiCleanArch.Persistence.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace RestApiCleanArch.Persistence
{
    public class RestApiCleanArchDbContextFactory : DesignTimeDbContextFactoryBase<RestApiCleanArchDbContext>
    {
        protected override RestApiCleanArchDbContext CreateNewInstance(DbContextOptions<RestApiCleanArchDbContext> options)
        {
            return new RestApiCleanArchDbContext(options);
        }
    }
}
