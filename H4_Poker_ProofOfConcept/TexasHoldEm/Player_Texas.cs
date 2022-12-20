using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H4_Poker_ProofOfConcept.Poco;

namespace H4_Poker_ProofOfConcept.TexasHoldEm
{
    public enum Role
    {
        NONE,
        DEALER,
        BIG_BLIND,
        SMALL_BLIND
    };

    internal class Player_Texas : Player<Card>
    {
        private Role role;


        public Role Role
        {
            get { return role; }
            set { role = value; }
        }
        public Player_Texas(string username) : base(username)
        {
        }
    }
}
