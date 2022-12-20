using H4_Poker_ProofOfConcept.Poco;
using H4_Poker_ProofOfConcept.TexasHoldEm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_Poker_ProofOfConcept.GameLogic
{
    internal class RoleManager
    {
        private readonly ObservableCollection<Player<Card>> _players;
        private int _currentPlayerIndex;

        public RoleManager(ObservableCollection<Player<Card>> players)
        {
            _players = players;
            _currentPlayerIndex = 0;
        }

        public void MoveRoles()
        {
            // Increment the current player index and wrap around if necessary
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;

            // Assign the new roles to the players
            ((Player_Texas)_players[_currentPlayerIndex]).Role = Role.DEALER;
            ((Player_Texas)_players[(_currentPlayerIndex + 1) % _players.Count]).Role = Role.BIG_BLIND;
            ((Player_Texas)_players[(_currentPlayerIndex + 2) % _players.Count]).Role = Role.SMALL_BLIND;

            // Clear the roles of the other players
            for (int i = 3; i < _players.Count; i++)
            {
                ((Player_Texas)_players[(_currentPlayerIndex + i) % _players.Count]).Role = Role.NONE;
            }
        }
    }

}
