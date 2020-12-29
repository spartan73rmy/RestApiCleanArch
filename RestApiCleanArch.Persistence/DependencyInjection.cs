using RestApiCleanArch.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;

namespace RestApiCleanArch.Persistence

{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext using SQL Server Provider
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                services.AddDbContext<RestApiCleanArchDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("RestApiCleanArchDatabase")));
            }
            else
            {
                services.AddDbContext<RestApiCleanArchDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("RestApiCleanArchDatabaseLinux")));
            }
            services.AddScoped<IRestApiCleanArchDbContext>(provider => provider.GetService<RestApiCleanArchDbContext>());
            return services;
        }
    }
}
