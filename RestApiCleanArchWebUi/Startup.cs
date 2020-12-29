using RestApiCleanArch.Application;
using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Options;
using RestApiCleanArch.Infraestructure;
using RestApiCleanArch.Infraestructure.Options;
using RestApiCleanArch.Persistence;
using RestApiCleanArch.WebUi.Common;
using RestApiCleanArch.WebUi.Helpers;
using RestApiCleanArch.WebUi.Options;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NSwag;
using NSwag.Generation.Processors.Security;
using Serilog;
using System.Linq;
using System.Text;

namespace RestApiCleanArch.WebUi
{
    public partial class Startup
    {
        private IServiceCollection services;
        private readonly ILogger<Startup> logger;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment, ILogger<Startup> logger)
        {
            Configuration = configuration;
            Environment = environment;
            this.logger = logger;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);

            // Add ability to inject context 
            services.AddHttpContextAccessor();

            services.AddInfrastructure(Configuration);
            services.AddPersistence(Configuration);
            services.AddApplication(Configuration);

            services.AddScoped<IUserAccessor, UserAccessor>();

            services
               .AddControllersWithViews()
               .AddNewtonsoftJson()
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IRestApiCleanArchDbContext>());

            services.AddHealthChecks()
                .AddDbContextCheck<RestApiCleanArchDbContext>();

            services.AddRazorPages();

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            // 
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = long.MaxValue;
            });

            ConfigureAuth(services);

            PrintSettings(Configuration);

            services.AddOpenApiDocument(document =>
            {
                document.Title = "RestApiCleanArch API";
                document.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
                //      new OperationSecurityScopeProcessor("JWT"));
            });

            this.services = services;
        }

        private void PrintSettings(IConfiguration configuration)
        {
            var email = configuration.GetSection("EmailService").Get<EmailServiceOptions>();
            var files = configuration.GetSection("FileService").Get<FileServiceOptions>();
            var app = configuration.GetSection("AppSettings").Get<AppSettings>();
            var auth = configuration.GetSection("AuthOptions").Get<AuthOptions>();
            var avatar = configuration.GetSection("AvatarService").Get<AvatarServiceOptions>();

            var fullSettingsJson = JsonConvert.SerializeObject(new
            {
                EmailService = email,
                FileService = files,
                AppSettings = app,
                AuthOptions = auth,
                Avatar = avatar
            }, Formatting.Indented);

            logger.LogInformation($"Loaded with config\r\n {fullSettingsJson}");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                RegisteredServicesPage(app);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
            }

            app.UseHealthChecks("/api/health");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // global cors policy
            app.UseCors(el => el
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();

            app.UseSerilogRequestLogging();
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            app.UseOpenApi(config =>
            {
                config.Path = "/api/swagger/{documentName}/api.json";
            }); // serve OpenAPI/Swagger documents
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api/swagger";
                settings.DocumentPath = "/api/swagger/{documentName}/api.json";
            }); // serve Swagger UI
            // app.UseReDoc(); // serve ReDoc UI

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }

        private void RegisteredServicesPage(IApplicationBuilder app)
        {
            app.Map("/services", builder => builder.Run(async context =>
            {
                var sb = new StringBuilder();
                sb.Append("<h1>Registered Services</h1>");
                sb.Append("<table><thead>");
                sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Instance</th></tr>");
                sb.Append("</thead><tbody>");
                foreach (var svc in services)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{svc.ServiceType.FullName}</td>");
                    sb.Append($"<td>{svc.Lifetime}</td>");
                    sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</tbody></table>");
                await context.Response.WriteAsync(sb.ToString());
            }));
        }
    }
}
