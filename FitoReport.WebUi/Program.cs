using FitoReport.Application.UseCases.Usuarios.Commands.CreateUsuario;
using FitoReport.Application.UseCases.Usuarios.Commands.ModificarPassword;
using FitoReport.Application.UseCases.Usuarios.Commands.RefreshCredentials;
using FitoReport.Persistence;
using Masking.Serilog;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Serilog;
using System;
using System.IO;

namespace FitoReport.WebUi
{
    public class Program
    {
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
        public static void Main(string[] args)
        {
            IdentityModelEventSource.ShowPII = true;
            Log.Logger = new LoggerConfiguration()
                .Destructure.ByMaskingProperties(opts =>
                {
                    opts.PropertyNames.Add(nameof(CreateUsuarioCommand.Password));
                    opts.PropertyNames.Add(nameof(ModificarPasswordCommand.PasswordActual));
                    opts.PropertyNames.Add(nameof(ModificarPasswordCommand.PasswordNuevo));
                    opts.PropertyNames.Add(nameof(RefreshCredentialsCommand.RefreshToken));
                    opts.PropertyNames.Add(nameof(RefreshCredentialsCommand.Token));
                    opts.Mask = "******";
                })
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var chikisitemaContext = services.GetRequiredService<FitoReportDbContext>();
                    chikisitemaContext.Database.Migrate();

                    FitoReportDbInitializer.Initialize(chikisitemaContext);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or initializing the database.");
                }
            }

            host.Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseSerilog()
                .UseStartup<Startup>();
        }
    }
}
