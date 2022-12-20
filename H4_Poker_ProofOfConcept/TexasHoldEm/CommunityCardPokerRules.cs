using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_Poker_ProofOfConcept.TexasHoldEm
{
    internal abstract class CommunityCardPokerRules : IRules
    {
        public abstract int MinimumPlayers { get; }
        public abstract int MaximumPlayers { get; }
    }
}
