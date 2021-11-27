namespace Hermes.Server.Api.Data.FileIO
{
	using Hermes.Server.Api.Core;

	using System.Collections;
	using System.Collections.Generic;

	public class TextFileDictionaryProvider : IDictionaryProvider
	{
		private readonly IEnumerable<string> dictionary;

		public TextFileDictionaryProvider(IEnumerable<string> dictionary)
		{
			this.dictionary = dictionary;
		}

		public IEnumerator<string> GetEnumerator() =>
			this.dictionary.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() =>
			this.GetEnumerator();
	}
}