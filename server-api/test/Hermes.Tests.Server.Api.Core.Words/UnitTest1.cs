namespace Hermes.Tests.Server.Api.Core.Words.Anagrams
{
	using Hermes.Server.Api.Core.Words;
	using Hermes.Server.Api.Core.Words.Anagrams;

	using FakeItEasy;
	using FluentAssertions;
	using Xunit;

	using System.Collections.Generic;

	public class AnagramsProviderTests
	{
		private readonly IDictionaryProviderFactory dictionaryProviderFactory;

		public AnagramsProviderTests()
		{
			this.dictionaryProviderFactory = A.Fake<IDictionaryProviderFactory>();
			A.CallTo(() => this.dictionaryProviderFactory.Create()).Returns(new DictionaryProviderFake());
		}

		[Theory]
		[InlineData("abc", new[] { "cab" })]
		[InlineData("dean", new[] { "and", "den", "end", "dean", "dane" })]
		public void GetAnagrams_returnsAnagrams(string input, string[] expect)
		{
			// arrange
			var target = new AnagramsProvider(this.dictionaryProviderFactory);

			// act
			var actual = target.GetAnagrams(input, 3);

			// assert
			actual.Should().BeEquivalentTo(expect);
		}

		class DictionaryProviderFake : List<string>, IDictionaryProvider
		{
			public DictionaryProviderFake()
			{
				this.Add("and");
				this.Add("cab");
				this.Add("den");
				this.Add("end");

				this.Add("dane");
				this.Add("dean");
			}
		}
	}
}