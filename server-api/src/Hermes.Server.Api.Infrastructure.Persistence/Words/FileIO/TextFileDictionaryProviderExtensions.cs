namespace Hermes.Server.Api.Infrastructure.Persistence.Words
{
	using Hermes.Server.Api.Core.Words;

	using Microsoft.Extensions.DependencyInjection;

	public static class DictionaryProviderExtensions
	{
		public static IServiceCollection ConfigureDictionaryProvider(this IServiceCollection services, System.Action<DictionaryProviderOptions> configure)
		{
			var options = new DictionaryProviderOptions(services);
			configure?.Invoke(options);

			// all IDictionaryProvider instances should be resolved the same way
			services.AddSingleton<IDictionaryProvider>(x => x.GetRequiredService<IDictionaryProviderFactory>().Create());

			return services;
		}
	}

	public class DictionaryProviderOptions
	{
		public DictionaryProviderOptions(IServiceCollection services)
		{
			this.Services = services;
		}

		public IServiceCollection Services { get; init; }
	}
}

namespace Hermes.Server.Api.Infrastructure.Persistence.Words.FileIO
{
	using Hermes.Server.Api.Core.Words;

	using Microsoft.Extensions.DependencyInjection;

	public static class TextFileDictionaryProviderExtensions
	{
		public static DictionaryProviderOptions AddTextFile(this DictionaryProviderOptions options)
		{
			options.Services.AddSingleton<IDictionaryProviderFactory, TextFileDictionaryProviderFactory>();
			
			return options;
		}
	}
}