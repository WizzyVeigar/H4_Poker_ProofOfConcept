using H4_Poker_ProofOfConcept;
using H4_Poker_ProofOfConcept.Poco;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.VisualBasic.FileIO;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

internal abstract class PokerTable : IRules
{
    //Delegate for broadcasting to all players
    public delegate void BroadCastEvent(string messageToReturn);

    //Delegate for broadcasting to a specific player, and waiting for his response (Usually a turn move)
    public delegate Task SendMessageAwaitResponseEvent<T>(Player<T> player, string message);

    public delegate void SendMessageNoResponseEvent<T>(Player<T> player, string message);
    /// <summary>
    /// Event for broadcasting to all players
    /// </summary>
    public event BroadCastEvent? BroadCast;

    //TODO Maybe unnecessary?
    /// <summary>
    /// Event for broadcasting to a specific player, and waiting for his response
    /// </summary>
    public event SendMessageAwaitResponseEvent<Card>? MessagePlayerResponseEvent;

    public event SendMessageNoResponseEvent<Card>? PlayerNoResponseEvent;
    /// <summary>
    /// Observable of players joining and leaving the room
    /// </summary>
    private ObservableCollection<Player<Card>> players = new ObservableCollection<Player<Card>>();
    public ObservableCollection<Player<Card>> Players
    {
        get { return players; }
        set { players = value; }
    }

    private int roomId;
    public int RoomId
    {
        get { return roomId; }
        set { roomId = value; }
    }

    //TODO Abstractize** it more, so SignalR can be replaced / different handler
    /// <summary>
    /// MessegeHandler for handling SignalR messages back n forth
    /// </summary>
    private SignalRMessenger messageHub;
    public SignalRMessenger MessageHub
    {
        get { return messageHub; }
        set { messageHub = value; }
    }

    public abstract int MinimumPlayers { get; }
    public abstract int MaximumPlayers { get; }



    /// <summary>
    /// Bool for if a hand is currently ongoing.
    /// </summary>
    protected bool GameOnGoing = false;

    /// <summary>
    /// This table's ruleset, which specifies what type of poker is at this table.
    /// DEBATE: Should this be changeable after initialization?
    /// </summary>
    /// Is this necessary? or should we just implement the rules on the subclass of pokertable?
    //private IRules ruleSet;
    //public IRules RuleSet { get { return ruleSet; } private set { ruleSet = value; } }

    /// <summary>
    /// An empty deck of cards, to hold playing cards. 
    /// This can always be of type <Card> since this is a poker table and you will always use normal playing cards
    /// </summary>
    protected List<Card> Deck = new List<Card>();

    public PokerTable(int roomId)
    {
        Players.CollectionChanged += Players_CollectionChanged;
        //this.RuleSet = ruleSet;
        RoomId = roomId;
        MessageHub = new SignalRMessenger();
    }

    /// <summary>
    /// Event method that handles a player leaving or joining a game and broadcasts it to the other players.
    /// </summary>
    /// <param name="sender">The player which has modified the observable</param>
    /// <param name="e">The Add or Remove of said player</param>
    private void Players_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        User user = (User)sender;
        if (user != null)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:

                    if (!GameOnGoing && Players.Count >= MinimumPlayers)
                    {
                        //this needs to start a new game
                        RunGame();
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    BroadCastMessage($"{user} has left the table");
                    break;
                default:
                    break;
            }
            BroadCastMessage($"{user} has joined the table");
        }
    }   
    protected virtual void BroadCastMessage(string v)
    {
        BroadCast?.Invoke(v);
    }

    protected virtual void SendMessageAwaitResponse(Player<Card> player, string message)
    {
        MessagePlayerResponseEvent?.Invoke(player, message);
    }

    protected virtual void SendMessageNoResponse(Player<Card> player, string message)
    {
        PlayerNoResponseEvent?.Invoke(player, message);
    }

    protected abstract void DealPlayers(int amountToDeal);
    protected abstract void RunGame();

    protected virtual Player<Card> DetermineWinner()
    {
        return Players[0];
    }

}
