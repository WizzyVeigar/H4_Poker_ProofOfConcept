internal class User
{
    public User()
    {
    }


    //Method for calling api and logging in
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
        string response = server.JoinRoom(pokerHubId, this);
        string[] data = response.Split("body");
        if (data[1] == "good")
        {
            //Go to room with data from response
            //Redirect to room with data[0]
        }
    }

    internal string ReceiveMessage(string message)
    {
        HandleMessage(message);
        return "Yes";
    }

    private void HandleMessage(string message)
    {
        throw new NotImplementedException();
    }
}