using DesignPatterns.GRASP.Solitaire.Core.Interfaces;
using DesignPatterns.GRASP.Solitaire.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.GRASP.Solitaire.Crossroads
{
    public sealed class SolitaireCrossroads
    {
        private int _singleCardsCount;
        private const int CARDS_COUNT = 52;

        private Queue<CrossroadsCard> _mainDeck;

        private CrossroadsCard[] _singleCards;

        private Stack<CrossroadsCard> _centerDeck;
        
        public SolitaireCrossroads(int singleCardsCount = 4)
        {
            _singleCardsCount = singleCardsCount;
        }

        public void GameInit()
        {
            // Initialization cards //
            var cards = new List<CrossroadsCard>(CARDS_COUNT);

            foreach (CardValue value in Enum.GetValues(typeof(CardValue))) {
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit))) {
                    cards.Add(new CrossroadsCard(value, suit));
                }
            }

            cards.Shuffle();
            _mainDeck = new Queue<CrossroadsCard>(cards);

        }
    }
}
