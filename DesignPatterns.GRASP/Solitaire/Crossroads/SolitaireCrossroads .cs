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
        private const int SINGLE_CARDS_COUNT = 4;
        private const int MAIN_DECK_SIZE = 52;

        private Stack<CrossroadsCard> _reserveStack;

        private CrossroadsCard[] _singleCards;

        private Stack<CrossroadsCard> _centralStack;
        
        public SolitaireCrossroads()
        {

        }

        public void GameInit()
        {
            // Initialization cards //
            var cards = new List<CrossroadsCard>(MAIN_DECK_SIZE);

            foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
            {
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                {
                    cards.Add(new CrossroadsCard(value, suit));
                }
            }

            cards.Shuffle();
            _reserveStack = new Stack<CrossroadsCard>(cards);

            // Initialize playing cards //
            _singleCards = new CrossroadsCard[SINGLE_CARDS_COUNT];
            _singleCards = _singleCards.Select(card => card = _reserveStack.Pop()).ToArray();

            _centralStack = new Stack<CrossroadsCard>();
            _centralStack.Push(_reserveStack.Pop());
        }

        public override string ToString()
        {
            return
                $"{_singleCards[0], 15}\n" +
                $"{_reserveStack.Peek()}{_singleCards[1], 8}{_centralStack.Peek(), 5}{_singleCards[2], 5}\n" +
                $"{_singleCards[3], 15}\n";
        }
    }
}
