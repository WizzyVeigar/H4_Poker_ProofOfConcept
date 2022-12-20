using H4_Poker_ProofOfConcept;

internal class User
{
    public User(string uname)
    {
        Username = uname;
    }

    private string username;

    public string Username
    {
        get { return username; }
        set { username = value; }
    }

    private string connId;

    public string ConnId
    {
        get { return connId; }
        set
        {
            if (string.IsNullOrEmpty(connId))
            {
                connId = value;
            }
        }
    }




    //Method for calling api and logging in
    //This is not necessary in the real program, where you make a user object after calling the login endpoint for the first time
    internal void Login(string userName)
    {
        Server server = new Server();
        string response = server.Login(userName);
        if (response == "good")
        {
            //Go to main page
        }
    }


    //Method for calling api and joining a room
    internal void JoinRoom(int pokerHubId)
    {
        Server server = new Server();
        string response = server.AddPlayerToRoom(pokerHubId, this);
        string[] data = response.Split("body");
        if (data[1] == "good")
        {
            //Go to room with data from response
            //Redirect to room with data[0]
        }
    }
}