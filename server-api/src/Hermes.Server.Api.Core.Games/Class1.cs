namespace Hermes.Server.Api.Core.Games
{
}

namespace Hermes.Server.Api.Core.Games.Cards
{
	using System.Linq;
	using System.Collections;
	using System.Collections.Generic;

	public enum Rank
	{
		Ace = 1,
		Two = 2,
		Three = 3,
		Four = 4,
		Five = 5,
		Six = 6,
		Seven = 7,
		Eight = 8,
		Nine = 9,
		Ten = 10,
		Jack = 11,
		Queen = 12,
		King = 13
	}

	public enum Suit
	{
		Clubs = 1,
		Diamonds = 2,
		Hearts = 3,
		Spades = 4
	}

	public record Card(Rank Rank, Suit Suit)
	{
		public override string ToString()
		{
			return $"{this.Rank} of {this.Suit}";
		}
	}

	public class Deck : IEnumerable<Card>
	{
		private readonly Stack<Card> cards;

		public Deck()
		{
			// get all values for suits and ranks
			var suits = System.Enum.GetValues<Suit>();
			var ranks = System.Enum.GetValues<Rank>();

			// create a new stack of playing cards
			this.cards = new Stack<Card>(from s in suits from r in ranks select new Card(r, s));
		}

		/// <inheritdoc />
		public IEnumerator<Card> GetEnumerator() =>
			this.cards.GetEnumerator();

		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator() =>
			this.GetEnumerator();
	}
}

namespace Hermes.Server.Api.Core.Games.Fours
{
}