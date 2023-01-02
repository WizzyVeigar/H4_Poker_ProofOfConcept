using H4_Poker_ProofOfConcept.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_Poker_ProofOfConcept
{
    internal class PotManager
    {
		private int pot;
		public int Pot
		{
			get { return pot; }
			set { pot = value; }
		}

		private int currentBet;

		public int CurrentBet
		{
			get { return currentBet; }
			set { currentBet = value; }
		}

		public void AddToPot<T>(Player<T> player, int potToAdd)
		{
			pot += potToAdd;
			player.TurkeyCoins -= potToAdd;
		}
	}
}
