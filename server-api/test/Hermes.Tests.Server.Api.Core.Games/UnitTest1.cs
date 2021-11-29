namespace Hermes.Tests.Server.Api.Core.Games.Cards
{
	using Hermes.Server.Api.Core.Games.Cards;
	using System;
	using System.Linq;
	using Xunit;

	public class DeckTests
	{
		[Fact]
		public void ctor_initializesDeck()
		{
			// act
			var actual = new Deck();

			// assert
			Assert.Equal(52, actual.Count());
		}
	}
}