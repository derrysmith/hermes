namespace Hermes.Server.Api.Core.Words.Anagrams
{
	using System.Collections.Generic;

	public interface IAnagramsProvider
	{
		IEnumerable<string> GetAnagrams(string characters, int minimum);
	}
}