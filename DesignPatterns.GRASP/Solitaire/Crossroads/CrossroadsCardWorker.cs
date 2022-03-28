using DesignPatterns.GRASP.Solitaire.Core.Extensions;
using DesignPatterns.GRASP.Solitaire.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.GRASP.Solitaire.Crossroads
{
    public enum CardType
    {
        Top = 0,
        Right = 1,
        Bottom = 2,
        Left = 3,
        Central = 4,
        Reserve = 5
    }

    internal class CrossroadsCardWorker
    {
        private Stack<CrossroadsCard?> _reserveStack;
        private CrossroadsCard?[] _singleCards;
        private Stack<CrossroadsCard?> _centralStack;

        public CrossroadsCardWorker() { }

        public void NewGame()
        {
            const int SINGLE_CARDS_COUNT = 4;
            const int MAIN_DECK_SIZE = 52;

            // Initialization cards //
            var cards = new List<CrossroadsCard?>(MAIN_DECK_SIZE);

            foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
            {
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                {
                    cards.Add(new CrossroadsCard(value, suit));
                }
            }

            cards.Shuffle();
            _reserveStack = new Stack<CrossroadsCard?>(cards);

            // Initialize playing cards //
            _singleCards = new CrossroadsCard?[SINGLE_CARDS_COUNT];
            _singleCards = _singleCards.Select(card => card = _reserveStack.Pop()).ToArray();

            _centralStack = new Stack<CrossroadsCard?>();
            _centralStack.Push(_reserveStack.Pop());
        }

        private void Remove(CardType cardType)
        {
            if (cardType is CardType.Top or CardType.Right or CardType.Bottom or CardType.Left)
            {
                _singleCards[(int)cardType] = null;

            }
            else if (cardType is CardType.Central)
            {
                _centralStack.Pop();
            }
            else if (cardType is CardType.Reserve)
            {
                _reserveStack.Pop();
            }

            UpdateCardTo(cardType);
        }

        private void Remove(params CardType[] cardTypes)
        {
            foreach (var type in cardTypes)
            {
                Remove(type);
            }
        }

        private void UpdateCardTo(CardType cardType)
        {
            CrossroadsCard? bufferCard = null;

            if (cardType is CardType.Top or CardType.Right or CardType.Bottom or CardType.Left)
            {
                if (_centralStack.TryPop(out bufferCard))
                {
                    _singleCards[(int)cardType] = bufferCard;
                }
                else
                {
                    if (_reserveStack.TryPop(out bufferCard))
                    {
                        _singleCards[(int)cardType] = bufferCard;
                    }

                    if (_reserveStack.TryPop(out bufferCard))
                    {
                        _centralStack.Push(bufferCard);
                    }
                }
            }
            else if (cardType is CardType.Central && _reserveStack.TryPop(out bufferCard))
            {
                _centralStack.Push(bufferCard);
            }
        }

        public bool TryRemoveCoupleCards(CardType cardTypeA, CardType cardTypeB)
        {
            if (TryPeekCard(cardTypeA, out CrossroadsCard? cardA) && TryPeekCard(cardTypeB, out CrossroadsCard? cardB))
            {
                if (cardA == cardB)
                {
                    Remove(cardTypeA, cardTypeB);
                    return true;
                }
            }

            return false;
        }

        public bool TryPutReserveToCental()
        {
            if (_reserveStack.TryPop(out CrossroadsCard? reserveCard))
            {
                _centralStack.Push(reserveCard);
                return true;
            }

            return false;
        }

        public bool TryPeekCard(CardType cardType, out CrossroadsCard? card)
        {
            return cardType switch
            {
                _ when cardType is CardType.Top 
                                or CardType.Right
                                or CardType.Bottom
                                or CardType.Left => (card = _singleCards[(int)cardType]) is not null,
                CardType.Central => _centralStack.TryPeek(out card),
                CardType.Reserve => _reserveStack.TryPeek(out card),

                _ => throw new NotSupportedException("Not supported card type")
            };
        }
    }
}
