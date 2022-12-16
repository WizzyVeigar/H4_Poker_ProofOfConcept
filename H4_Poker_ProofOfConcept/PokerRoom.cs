using Microsoft.VisualBasic.FileIO;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

internal class PokerRoom
{
    public delegate string BroadCastEvent(string MessageToReturn);

    public event BroadCastEvent BroadCast;
    public ObservableCollection<User> Players = new ObservableCollection<User>();
    bool GameOnGoing = false;
    IRules ruleSet;
    private List<Card> Deck = new List<Card>();

    public PokerRoom(IRules ruleSet)
    {
        Players.CollectionChanged += Players_CollectionChanged;
        this.ruleSet = (TexasHoldEmRules)ruleSet;
    }

    private void Players_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                if (GameOnGoing)
                {

                }
                if (Players.Count >= ruleSet.PlayersNeededAmount)
                {

                }
                break;
            case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
            default:
                break;
        }

        BroadCastMessage("This has happened");
    }

    private void BroadCastMessage(string v)
    {
        BroadCast?.Invoke(v);
    }
}
