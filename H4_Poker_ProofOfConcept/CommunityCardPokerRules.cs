using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_Poker_ProofOfConcept
{
    internal abstract class CommunityCardPokerRules : IRules
    {
        public abstract int MinimumPlayers { get; }
        public abstract int MaximumPlayers { get; }

        protected virtual void HandleFold()
        {

        }
        protected virtual void HandleCheck()
        {

        }
        protected virtual void HandleCall()
        {

        }
        protected virtual void HandleRaise(int amount)
        {

        }
    }
}
