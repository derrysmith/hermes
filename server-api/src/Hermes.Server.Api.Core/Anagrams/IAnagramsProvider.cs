namespace Hermes.Server.Api.Core.Anagrams
{
	using System.Collections.Generic;

	public interface IAnagramsProvider
	{
		IEnumerable<string> GetAnagrams(string characters, int minimum);
	}
}