namespace Hermes.Server.Api.Infrastructure.Persistence.Words.FileIO
{
	using Hermes.Server.Api.Core.Words;

	using System.Linq;
	using System.Linq.Expressions;

	public class TextFileDictionaryProviderFactory : IDictionaryProviderFactory
	{
		public IDictionaryProvider Create()
		{
			var dictionary = Resources.DictionaryProvider.Words
				.Split(System.Environment.NewLine)
					.Select(str => str.Replace("\r", string.Empty));

			return new TextFileDictionaryProvider(dictionary);
		}
	}
}