using H4_Poker_ProofOfConcept.Poco;

internal class Server
{
    public Server()
    {
    }

    List<PokerTable> RoomList = new List<PokerTable>() { new PokerTable(new TexasHoldEmRules(), 1), new PokerTable(new TexasHoldEmRules(), 2) };

    //Api endpoint
    internal string Login(string userName)
    {
        return "good";
    }

    //Api endpoint
    //User wants to join the specific game
    internal string AddPlayerToRoom(int hubId, User user)
    {
        PokerTable table = FindRoomById(hubId);
        if (table == null)
        {
            return "Room not found";
        }

        if (table.RuleSet is TexasHoldEmRules)
        {
            if (table.Players.Count != table.RuleSet.MaximumPlayers)
            {
                Player<Card> player = new Player<Card>(user.Username);
                table.Players.Add(player);
                SubscribeToRoomEvents(table);
            }
            else
                return "Room was Full";
        }

        return "Granted";
    }

    private PokerTable FindRoomById(int hubId)
    {
        return RoomList.FirstOrDefault(room => room.RoomId == hubId);
    }

    private bool SubscribeToRoomEvents(PokerTable tableToJoin)
    {
        tableToJoin.BroadCast += tableToJoin.MessageHub.BroadCastMessage;
        tableToJoin.MessagePlayerEvent += tableToJoin.MessageHub.SendMessageAwaitResponse;
        return true;
    }
}