using System;
using System.Diagnostics.CodeAnalysis;
using DesignPatterns.GRASP.Solitaire.Core;
using DesignPatterns.GRASP.Solitaire.Core.Extensions;
using DesignPatterns.GRASP.Solitaire.Core.Interfaces;

namespace DesignPatterns.GRASP.Solitaire.Crossroads
{
    public struct CrossroadsCard : ICard
    {
        public CardValue Value { get; }
        public CardSuit Suit { get; }

        public CrossroadsCard(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }

        public static bool operator >(CrossroadsCard a, CrossroadsCard b)
        {
            return a.Value > b.Value;
        }

        public static bool operator <(CrossroadsCard a, CrossroadsCard b)
        {
            return a.Value < b.Value;
        }

        public static bool operator ==(CrossroadsCard a, CrossroadsCard b)
        {
            return a.Value == b.Value;
        }

        public static bool operator !=(CrossroadsCard a, CrossroadsCard b)
        {
            return a.Value != b.Value;
        }

        public override string ToString() => this.ToStringExtension();
    }
}