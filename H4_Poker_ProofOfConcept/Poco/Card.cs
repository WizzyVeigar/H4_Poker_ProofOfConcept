public enum Rank
{
    ACE,
    TWO,
    THREE,
    FOUR,
    FIVE,
    SIX,
    SEVEN,
    EIGHT,
    NINE,
    JACK,
    QUEEN,
    KING
};

public enum Suit
{
    SPADES,
    HEARTS,
    DIAMONDS,
    CLUBS
};

internal class Card
{
    public Rank Rank { get; set; }
    public Suit Suit { get; set;}

    public Card(Rank rank, Suit suit)
    {
        Rank = rank;
        Suit = suit;
    }
}