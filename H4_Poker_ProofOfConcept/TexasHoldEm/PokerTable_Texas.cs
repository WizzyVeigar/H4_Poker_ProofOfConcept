using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H4_Poker_ProofOfConcept.GameLogic;

namespace H4_Poker_ProofOfConcept.TexasHoldEm
{
    internal class PokerTable_Texas : PokerTable
    {
        bool hasRaised = false;

        public PokerTable_Texas(IRules ruleSet, int roomId) : base(ruleSet, roomId)
        {
            roleManager = new RoleManager(Players);
        }

        RoleManager roleManager;

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
                roleManager.MoveRoles();
                //Notify users of what role they are
                //Maybe put this in role manager?
                for (int i = 0; i < Players.Count; i++)
                {
                    switch (((Player_Texas)Players[i]).Role)
                    {
                        case Role.NONE:
                            break;
                        case Role.DEALER:
                        case Role.BIG_BLIND:
                        case Role.SMALL_BLIND:
                            SendMessageToPlayerAwaitResponse(Players[i], $"You are {((Player_Texas)Players[i]).Role}");

                            break;
                    }
                }
                //Pay blinds

                //Deal cards
                do
                {
                    hasRaised = false;
                    BettingRound();
                } while (hasRaised);

                //Deal 3 cards
                do
                {
                    hasRaised = false;
                    BettingRound();
                } while (hasRaised);

                //Deal 1 card
                do
                {
                    hasRaised = false;
                    BettingRound();
                } while (hasRaised);

                //Deal 1 card
                do
                {
                    hasRaised = false;
                    BettingRound();
                } while (hasRaised);

                //End round
                do
                {
                    hasRaised = false;
                    BettingRound();
                } while (hasRaised);

                DetermineWinner();
            }
        }

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

    }
}
