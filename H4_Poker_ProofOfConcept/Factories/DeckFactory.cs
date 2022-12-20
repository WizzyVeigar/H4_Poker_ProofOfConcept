using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_Poker_ProofOfConcept.Factories
{
    internal abstract class DeckFactory<T>
    {
        protected DeckFactory() { }

        protected abstract IList<T> CreateDeck();
    }
}
