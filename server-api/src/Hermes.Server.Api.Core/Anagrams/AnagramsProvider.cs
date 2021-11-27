namespace Hermes.Server.Api.Core.Anagrams
{
	using System.Linq;
	using System.Collections.Generic;

	public class AnagramsProvider : IAnagramsProvider
	{
		private IDictionary<string, IList<string>> anagramsDictionary;

		public AnagramsProvider(IDictionaryProvider dictionary)
		{
			this.anagramsDictionary = new Dictionary<string, IList<string>>();

			foreach (var word in dictionary)
			{
				// create anagram key
				var anagramKey = this.CreateAnagramKey(word);

				if (this.anagramsDictionary.ContainsKey(anagramKey))
					this.anagramsDictionary[anagramKey].Add(word);
				else
					this.anagramsDictionary.Add(anagramKey, new List<string> { word });
			}
		}

		public IEnumerable<string> GetAnagrams(string characters, int minimum)
		{
			if (string.IsNullOrWhiteSpace(characters))
				throw new System.ArgumentNullException(nameof(characters));

			var anagrams = new List<string>();
			var ancombos = this.CreateAnagramCombos(characters, minimum, characters.Length);

			foreach (var combo in ancombos)
			{
				if (this.anagramsDictionary.ContainsKey(combo))
					anagrams.AddRange(this.anagramsDictionary[combo]);
			}

			return anagrams.OrderBy(str => str.Length).ThenBy(str => str);
		}

		private string CreateAnagramKey(string word) =>
			string.Concat(word.OrderBy(c => c)).ToLower();

		private IEnumerable<string> CreateAnagramCombos(string chars, int min, int max)
		{
			var combinations = Enumerable.Range(0, 1 << chars.Length)
				.Select(e => string.Concat(Enumerable.Range(0, chars.Length)
					.Select(b => (e & (1 << b)) == 0 ? (char?)null : chars[b])));

			return combinations.Where(c => c.Length >= min && c.Length <= max)
				.Select(str => this.CreateAnagramKey(str)).Distinct();
		}
	}
}