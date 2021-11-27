namespace Hermes.Server.Api.Data.FileIO
{
	using Hermes.Server.Api.Core;

	using System.Linq;
	using System.Linq.Expressions;

	public class TextFileDictionaryProviderFactory : IDictionaryProviderFactory
	{
		public IDictionaryProvider Create(string culture = null)
		{
			var dictionary = Resources.DictionaryProvider.Words
				.Split(System.Environment.NewLine)
					.Select(str => str.Replace("\r", string.Empty));

			return new TextFileDictionaryProvider(dictionary);
		}
	}
}