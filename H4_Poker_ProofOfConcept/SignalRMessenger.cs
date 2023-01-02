using H4_Poker_ProofOfConcept.Poco;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_Poker_ProofOfConcept
{
    //Class used to send and receive messages from the players on the assigned PokerTable
    internal class SignalRMessenger : Hub
    {
        public void BroadCastMessage(string message)
        {
            Clients.All.BroadCast(message);
        }
        public async Task<string> SendMessageAwaitResponse<T>(Player<T> player, string message)
        {
            // Send the message to the client
            await Clients.Client(player.Connection.ConnectionId)
                .SendAsync("ReceiveMessage", message);


            // Wait for the response from the client
            string response = await Clients.Client(player.Connection.ConnectionId)
                .SendAsync<string>("GetResponse");

            return response;
        }

        public async void SendMessage<T>(Player<T> player, string message)
        {
            // Send the message to the client
            await Clients.Client(player.Connection.ConnectionId)
                .SendAsync("ReceiveMessage", message);
        }
    }
}
