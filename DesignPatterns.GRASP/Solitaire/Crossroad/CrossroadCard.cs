using System;
using System.Diagnostics.CodeAnalysis;
using DesignPatterns.GRASP.Solitaire.Core.Interfaces;

namespace DesignPatterns.GRASP.Solitaire.Crossroad
{
    internal struct CrossroadCard : ICard
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