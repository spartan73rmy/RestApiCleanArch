using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace RestApiCleanArch.Persistence.Infraestructure
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> :
        IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string ConnectionStringName = "RestApiCleanArchDatabase";
        private const string ConnectionStringNameLinux = "RestApiCleanArchDatabaseLinux";

        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}RestApiCleanArch.WebUi", Path.DirectorySeparatorChar);
            return Create(basePath, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        }

        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        private TContext Create(string basePath, string environmentName)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            string connectionString;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                connectionString = configuration.GetConnectionString(ConnectionStringName);
            else
                connectionString = configuration.GetConnectionString(ConnectionStringNameLinux);

            return Create(connectionString);
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
            {
                optionsBuilder.UseNpgsql(connectionString);
            }

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}
