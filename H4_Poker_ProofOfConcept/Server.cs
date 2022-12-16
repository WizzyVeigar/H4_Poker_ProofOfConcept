internal class Server
{
    public Server()
    {
    }

    List<PokerRoom> RoomList = new List<PokerRoom>() { new PokerRoom(), new PokerRoom() };

    //Api endpoint
    internal string Login(string userName)
    {
        return "good";
    }

    //Api endpoint
    //User wants to join the specific game
    internal string JoinRoom(int hubId, User user)
    {
        PokerRoom room = FindRoomById(hubId);
        SubscribeToRoomEvents(room, user);
        return "Granted";
    }

    private PokerRoom FindRoomById(int hubId)
    {
        throw new NotImplementedException();
    }

    private bool SubscribeToRoomEvents(PokerRoom roomToJoin, User user)
    {
        roomToJoin.Players.Add(user);
        roomToJoin.BroadCast += user.ReceiveMessage;

        return true;
    }
}