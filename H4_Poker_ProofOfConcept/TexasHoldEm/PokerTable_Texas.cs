using H4_Poker_ProofOfConcept.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_Poker_ProofOfConcept.TexasHoldEm
{
    internal class PokerTable_Texas : PokerTable
    {
        public PokerTable_Texas(IRules ruleSet, int roomId) : base(ruleSet, roomId)
        {
        }


        bool hasRaised = false;
        /// <summary>
        /// Method for players to bet on the given round
        /// </summary>
        private async void BettingRound()
        {
            foreach (Player_Texas userTurn in Players)
            {
                Player_Texas currentUser = userTurn;
                string dsa = await MessageHub.SendMessageAwaitResponse(currentUser, "YOUR TURN");

                //userTurn
                if (/*player raises */true)
                {
                    hasRaised = true;
                }
            }
        }

        protected override void RunGame()
        {

            BroadCastMessage("NEW GAME BEGINS");
            //current user turn
            //message current user("YOUR TURN")
            //if sender = current user
            //Move current user turn
            while (GameOnGoing)
            {
                //Move roles
                //Deal cards
                do
                {
                    hasRaised = false;
                    BettingRound();
                } while (hasRaised);
                //Deal 3 cards
                //Deal 1 card
                //Deal 1 card
                //End round
            }
        }
    }
}
