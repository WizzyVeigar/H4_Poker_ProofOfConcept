using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_Poker_ProofOfConcept.Factories
{
    internal class CardDeckFactory : DeckFactory<Card>
    {
        public override List<Card> CreateDeck()
        {
            List<Card> cards = new List<Card>();

            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Add(new Card(rank, suit));
                }
            }

            return cards;
        }
    }
}
