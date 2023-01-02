using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_Poker_ProofOfConcept.Poco
{
    public enum Player_Actions
    {
        CALL,
        RAISE,
        CHECK,
        FOLD
    };

    internal class Player<T>
    {
        private string username = "default";

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        private List<T> cards;
        public List<T> Cards
        {
            get { return cards; }
            set { cards = value; }
        }

        private HubConnection connection;
        public HubConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        //Maybe change this to struct / obj later
        private int turkeyCoins;
        public int TurkeyCoins
        {
            get { return turkeyCoins; }
            set { turkeyCoins = value; }
        }


        public Player(string username, int _turkeyCoins = 200)
        {
            Username = username;
            cards= new List<T>();
            turkeyCoins = _turkeyCoins;
        }
    }
}
