using System;
using DesignPatterns.GRASP.Solitaire.Core.Interfaces;

namespace DesignPatterns.GRASP.Solitaire.Crossroad
{
    internal class CrossroadCard : ICard
    {
        public CardValue Value { get; init; }
        public CardSuit Suit { get; init; }

        public static bool operator >(CrossroadCard a, CrossroadCard b)
        {
            return a.Value > b.Value;
        }

        public static bool operator <(CrossroadCard a, CrossroadCard b)
        {
            return a.Value < b.Value;
        }

        public static bool operator ==(CrossroadCard a, CrossroadCard b)
        {
            return a.Value == b.Value;
        }

        public static bool operator !=(CrossroadCard a, CrossroadCard b)
        {
            return a.Value != b.Value;
        }
    }
}