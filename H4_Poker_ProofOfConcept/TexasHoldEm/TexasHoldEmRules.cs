using H4_Poker_ProofOfConcept.TexasHoldEm;

internal class TexasHoldEmRules : CommunityCardPokerRules
{
    public override int MinimumPlayers => 2;

    public override int MaximumPlayers => 9;
}