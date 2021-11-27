namespace Hermes.Server.Api.Anagrams
{
	using System.Collections.Generic;

	public record GetAnagramsResults(IEnumerable<string> Anagrams);
}