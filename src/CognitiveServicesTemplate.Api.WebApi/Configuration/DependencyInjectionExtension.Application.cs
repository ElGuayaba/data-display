using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CognitiveServicesTemplate.Application.Implementation.Service;
using Scrutor;

namespace CognitiveServicesTemplate.Api.WebApi.Configuration
{
    public static partial class DependencyInjectionExtension
    {
        private static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<OcrService>()
                .AddClasses(classes =>
                    classes.Where(c => c.Name.EndsWith("Service")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            return services;
        }
    }
}