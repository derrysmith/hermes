namespace Hermes.Tests.Server.Api.Core
{
	using Hermes.Server.Api.Core;
	using Hermes.Server.Api.Core.Anagrams;
	using Hermes.Server.Api.Data.FileIO;
	using Xunit;

	public class AnagramsProviderTests
	{
		[Theory]
		[InlineData("dean")]
		[InlineData("work")]
		[InlineData("creek")]
		[InlineData("having")]
		public void GetAnagrams_returnsAnagrams(string characters)
		{
			// arrange
			var dictionary = new TextFileDictionaryProviderFactory().Create();
			var provider = new AnagramsProvider(dictionary);

			// act
			var anagrams = provider.GetAnagrams(characters, 3);

			// assert
			Assert.NotEmpty(anagrams);
		}
	}
}