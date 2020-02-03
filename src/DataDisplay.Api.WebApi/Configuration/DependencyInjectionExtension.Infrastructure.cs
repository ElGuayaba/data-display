using DataDisplay.Infrastructure.Implementation.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace DataDisplay.Api.WebApi.Configuration
{
	public static partial class DependencyInjectionExtension
	{
		private static IServiceCollection AddInfrastructureClients(this IServiceCollection services, IConfiguration configuration)
		{
			services.Scan(scan => scan
				.FromAssemblyOf<DataRepository>()
				.AddClasses(classes =>
					classes.Where(c => c.Name.EndsWith("Repository")))
				.UsingRegistrationStrategy(RegistrationStrategy.Skip)
				.AsMatchingInterface()
				.WithScopedLifetime());

			return services;
		}
	}
}
