namespace Hermes.Server.Api.Core
{
	public interface IDictionaryProviderFactory
	{
		IDictionaryProvider Create(string culture = default);
	}
}