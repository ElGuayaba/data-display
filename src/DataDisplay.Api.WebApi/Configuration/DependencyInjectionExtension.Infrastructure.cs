using CognitiveServicesTemplate.Infrastructure.Implementation.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace CognitiveServicesTemplate.Api.WebApi.Configuration
{
	public static partial class DependencyInjectionExtension
	{
		private static IServiceCollection AddInfrastructureClients(this IServiceCollection services, IConfiguration configuration)
		{
			services.Scan(scan => scan
				.FromAssemblyOf<OcrClient>()
				.AddClasses(classes =>
					classes.Where(c => c.Name.EndsWith("Client")))
				.UsingRegistrationStrategy(RegistrationStrategy.Skip)
				.AsImplementedInterfaces()
				.WithScopedLifetime());

			return services;
		}
	}
}
