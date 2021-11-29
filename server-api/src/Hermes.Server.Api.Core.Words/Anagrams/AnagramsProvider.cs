namespace Hermes.Server.Api.Core.Words.Anagrams
{
	using System.Collections.Generic;
	using System.Linq;

	public class AnagramsProvider : IAnagramsProvider
	{
		private readonly IDictionary<string, IList<string>> anagramsByKey;

		public AnagramsProvider(IDictionaryProviderFactory dictionaryProviderFactory)
		{
			this.anagramsByKey = this.GetAnagramsByKey(dictionaryProviderFactory.Create());
		}

		public IEnumerable<string> GetAnagrams(string characters, int minimum)
		{
			var anagrams = new List<string>();

			// get all combinations of keys
			var anagramKeyCombinations = this.GetAnagramKeyCombinations(characters, minimum, characters.Length);

			foreach (var anagramKeyCombination in anagramKeyCombinations)
				if (this.anagramsByKey.ContainsKey(anagramKeyCombination))
					anagrams.AddRange(this.anagramsByKey[anagramKeyCombination]);

			return anagrams.OrderBy(str => str.Length).ThenBy(str => str);
		}

		private string GetAnagramKey(string characters) =>
			string.Concat(characters.OrderBy(c => c));

		private IEnumerable<string> GetAnagramKeyCombinations(string characters, int min, int max)
		{
			var charactersShiftArray = Enumerable.Range(0, 1 << characters.Length);
			var charactersIndexArray = Enumerable.Range(0, characters.Length);

			var combinations = charactersShiftArray.Select(i => string.Concat(charactersIndexArray
				.Select(j => (i & (1 << j)) == 0 ? (char?)null : characters[j])))
					.Where(str => str.Length >= min && str.Length <= max)
						.Select(str => this.GetAnagramKey(str))
							.Distinct();

			return combinations;
		}

		private IDictionary<string, IList<string>> GetAnagramsByKey(IDictionaryProvider dictionary)
		{
			var anagrams = new Dictionary<string, IList<string>>();

			foreach (var word in dictionary)
			{
				// create anagram key
				var anagramKey = this.GetAnagramKey(word);

				// create new anagram list or add to an existing one for the given anagram key
				if (anagrams.ContainsKey(anagramKey))
					anagrams[anagramKey].Add(word);
				else
					anagrams.Add(anagramKey, new List<string> { word });
			}

			return anagrams;
		}
	}
}