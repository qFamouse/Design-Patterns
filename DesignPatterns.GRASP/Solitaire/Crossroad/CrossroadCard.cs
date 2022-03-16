using System;
using System.Diagnostics.CodeAnalysis;
using DesignPatterns.GRASP.Solitaire.Core;
using DesignPatterns.GRASP.Solitaire.Core.Extensions;
using DesignPatterns.GRASP.Solitaire.Core.Interfaces;

namespace DesignPatterns.GRASP.Solitaire.Crossroad
{
    public struct CrossroadCard : ICard
    {
        public CardValue Value { get; }
        public CardSuit Suit { get; }

        public CrossroadCard(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }

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

        public override string ToString() => this.ToStringExtension();
    }
}