using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_Poker_ProofOfConcept.Poco
{
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

        public Player(string username)
        {
            Username = username;
        }
    }
}
