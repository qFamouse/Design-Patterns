using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.GRASP.Solitaire.Core.Interfaces;
using DesignPatterns.GRASP.Solitaire.Crossroads;

namespace DesignPatterns.GRASP.Solitaire.Core.Extensions
{
    public static class CardExtension
    {
        public static string ToStringExtension(this ICard card)
        {
            string value = card.Value switch
            {
                CardValue.A => "A",
                CardValue.II => "2",
                CardValue.III => "3",
                CardValue.IV => "4",
                CardValue.V => "5",
                CardValue.VI => "6",
                CardValue.VII => "7",
                CardValue.VIII => "8",
                CardValue.IX => "9",
                CardValue.X => "10",
                CardValue.J => "J",
                CardValue.Q => "Q",
                CardValue.K => "K",
                _ => "?"
            };

            char suit = card.Suit switch
            {
                CardSuit.Clubs => '\u2663', // ♣
                CardSuit.Diamonds => '\u2666', // ♦
                CardSuit.Hearts => '\u2665', // ♥
                CardSuit.Spades => '\u2660', // ♠
                _ => '?'
            };

            return $"{value}{suit}";
        }
        /// <summary>
        /// Fisher–Yates shuffle (https://en.wikipedia.org/wiki/Fisher–Yates_shuffle)
        /// </summary>
        /// <typeparam name="ICard">Interface for all cards</typeparam>
        /// <param name="cards">List of cards to be shuffled</param>
        public static void Shuffle<ICard>(this IList<ICard> cards)
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (cards[k], cards[n]) = (cards[n], cards[k]);
            }
        }
    }
}