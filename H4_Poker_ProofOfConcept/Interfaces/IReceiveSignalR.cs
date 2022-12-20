using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_Poker_ProofOfConcept.Interfaces
{
    public interface IReceiveSignalR
    {
        public string ReceiveMessage(string message);
        public void HandleMessage(string message);
    }
}
