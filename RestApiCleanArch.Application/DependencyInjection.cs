using RestApiCleanArch.Application.Infraestructure;
using RestApiCleanArch.Application.Options;
using RestApiCleanArch.Application.Security;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace RestApiCleanArch.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // configure strongly typed settings objects
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // Add MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestAuthorizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            // Add authentication services
            services.RegisterAllTypes(typeof(IAuthenticatedRequest<,>).Assembly, typeof(IAuthenticatedRequest<,>));

            return services;
        }

        public static void RegisterAllTypes(this IServiceCollection services, Assembly assembly, Type type, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var typesFromAssemblies = assembly
                .DefinedTypes
                .Where(t => t.IsClass
                    && !t.IsAbstract
                    && t.AsType().ImplementsGenericInterface(type)
                );
            foreach (var currType in typesFromAssemblies)
            {
                var interf = currType.GetInterfaces().Where(el => el.IsGenericType && el.GetGenericTypeDefinition() == type).Single();
                services.Add(new ServiceDescriptor(interf, currType, lifetime));
            }
        }

        private static bool ImplementsGenericInterface(this Type type, Type interfaceType)
        {
            return type.IsGenericType(interfaceType) || type.GetTypeInfo().ImplementedInterfaces.Any(@interface => @interface.IsGenericType(interfaceType));
        }

        private static bool IsGenericType(this Type type, Type genericType)
        {
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericType;
        }
    }
}
