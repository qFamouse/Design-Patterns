namespace DesignPatterns.GRASP.Solitaire.Core.Interfaces
{
    internal enum CardValue
    {
        A    = 1,
        II   = 2,
        III  = 3,
        IV   = 4,
        V    = 5,
        VI   = 6,
        VII  = 7,
        VIII = 8,
        IX   = 9,
        X    = 10,
        J    = 11,
        Q    = 12,
        K    = 13,
    }

    internal enum CardSuit
    {
        Сlubs,
        Diamonds,
        Hearts,
        Spades
    }

    internal interface ICard
    {
        CardValue Value { get; }
        CardSuit Suit { get; }
    }
}