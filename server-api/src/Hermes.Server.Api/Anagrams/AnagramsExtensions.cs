namespace Hermes.Server.Api.Anagrams
{
	using Hermes.Server.Api.Core.Words.Anagrams;
	using Microsoft.Extensions.DependencyInjection;

	public static class AnagramsExtensions
	{
		public static IServiceCollection AddAnagrams(this IServiceCollection services)
		{
			services.AddSingleton<IAnagramsProvider, AnagramsProvider>();
			return services;
		}
	}
}