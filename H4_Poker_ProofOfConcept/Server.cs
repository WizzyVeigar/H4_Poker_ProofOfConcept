using H4_Poker_ProofOfConcept.Poco;
using H4_Poker_ProofOfConcept.TexasHoldEm;

internal class Server
{
    /// <summary>
    /// List of all tables
    /// </summary>
    List<PokerTable> Tables = new List<PokerTable>() { new PokerTable_Texas(new TexasHoldEmRules(), 1), new PokerTable_Texas(new TexasHoldEmRules(), 2) };

    //Api endpoint
    //call a loginManager
    internal string Login(string userName)
    {
        return "good";
    }

    //Api endpoint
    //User wants to join the specific game
    internal string AddPlayerToRoom(int hubId, User user)
    {
        PokerTable table = FindTableById(hubId);
        if (table == null)
        {
            return "Room not found";
        }
        //Check for what type of game player is joining
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

    private PokerTable FindTableById(int hubId)
    {
        return Tables.FirstOrDefault(room => room.RoomId == hubId);
    }

    private bool SubscribeToRoomEvents(PokerTable tableToJoin)
    {
        tableToJoin.BroadCast += tableToJoin.MessageHub.BroadCastMessage;
        tableToJoin.MessagePlayerEvent += tableToJoin.MessageHub.SendMessageAwaitResponse;
        return true;
    }
}