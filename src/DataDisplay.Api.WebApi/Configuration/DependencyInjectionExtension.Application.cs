using DataDisplay.Application.Implementation.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace DataDisplay.Api.WebApi.Configuration
{
    public static partial class DependencyInjectionExtension
    {
        private static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<DataService>()
                .AddClasses(classes =>
                    classes.Where(c => c.Name.EndsWith("Service")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithTransientLifetime());
            
            return services;
        }
    }
}