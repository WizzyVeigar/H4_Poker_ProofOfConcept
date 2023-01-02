namespace H4_Poker_ProofOfConcept.Interfaces
{
    internal interface ICommunityCardPokerRules : IRules
    {
        void DealCommunity(int amountToDeal);
    }
}