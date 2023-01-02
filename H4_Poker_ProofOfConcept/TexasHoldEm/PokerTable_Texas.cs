using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H4_Poker_ProofOfConcept.Factories;
using H4_Poker_ProofOfConcept.GameLogic;
using H4_Poker_ProofOfConcept.Poco;

namespace H4_Poker_ProofOfConcept.TexasHoldEm
{
    internal class PokerTable_Texas : PokerTable, ITexasHoldEmRules
    {
        bool hasRaised = false;
        int smallBlind = 5;
        int bigBlind = 10;
        CardDeckFactory deckFactory;
        RoleManager roleManager;
        PotManager potManager;

        public override int MinimumPlayers => 2;

        public override int MaximumPlayers => 9;

        public PokerTable_Texas(int roomId) : base(roomId)
        {
            roleManager = new RoleManager(Players);
            deckFactory = new CardDeckFactory();
            potManager = new PotManager();

            //Subscribe to hub events
            BroadCast += MessageHub.BroadCastMessage;
            MessagePlayerResponseEvent += MessageHub.SendMessageAwaitResponse;
            PlayerNoResponseEvent += MessageHub.SendMessage;
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
                            break;
                        case Role.BIG_BLIND:
                            potManager.AddToPot(Players[i], smallBlind);
                            break;
                        case Role.SMALL_BLIND:
                            potManager.AddToPot(Players[i], bigBlind);
                            break;
                    }
                    if (((Player_Texas)Players[i]).Role > 0)
                        SendMessageAwaitResponse(Players[i], $"You are {((Player_Texas)Players[i]).Role}");
                }

                //Pay blinds

                //Deal cards
                DealPlayers(2);

                for (int i = 0; i < 5; i++)
                {
                    do
                    {
                        hasRaised = false;
                        BettingRound();
                    } while (hasRaised);

                    if (i == 0)
                    {
                        //Deal 3 cards
                        DealCommunity(3);
                    }
                    //only deal for 3 of the 5 betting rounds
                    else if (i >= 1 && i < 4)
                    {
                        //Deal 1 card
                        DealCommunity(1);
                    }
                }
                //End round
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

        protected override void DealPlayers(int amountToDeal)
        {
            //Do this elsewhere
            if (Deck.Count != 52)
            {
                Deck = deckFactory.CreateDeck();
                Deck.Shuffle();
            }

            for (int j = 0; j < amountToDeal; j++)
            {
                for (int i = 0; i < Players.Count; i++)
                {
                    Players[i].Cards.Add(Deck.First());
                    Deck.RemoveAt(0);
                }
            }
        }

        public void DealCommunity(int amountToDeal)
        {

        }
    }
}
