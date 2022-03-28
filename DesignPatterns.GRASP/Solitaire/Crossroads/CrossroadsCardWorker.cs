using DesignPatterns.GRASP.Solitaire.Core.Extensions;
using DesignPatterns.GRASP.Solitaire.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.GRASP.Solitaire.Crossroads
{
    public enum CardPosition
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
        public int DeckSize => _reserveStack.Count;

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

        public bool TryRemoveCoupleCards(CardPosition cardPosA, CardPosition cardPosB)
        {
            if (TryPeekCard(cardPosA, out CrossroadsCard? cardA) && TryPeekCard(cardPosB, out CrossroadsCard? cardB))
            {
                if (cardA == cardB)
                {
                    Remove(cardPosA, cardPosB);
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

        public bool TryPeekCard(CardPosition cardPos, out CrossroadsCard? card)
        {
            return cardPos switch
            {
                _ when cardPos is CardPosition.Top
                                or CardPosition.Right
                                or CardPosition.Bottom
                                or CardPosition.Left => (card = _singleCards[(int)cardPos]) is not null,
                CardPosition.Central => _centralStack.TryPeek(out card),
                CardPosition.Reserve => _reserveStack.TryPeek(out card),

                _ => throw new NotSupportedException("Not supported card position")
            };
        }

        #region Private Methods

        private void Remove(CardPosition cardPos)
        {
            if (cardPos is CardPosition.Top or CardPosition.Right or CardPosition.Bottom or CardPosition.Left)
            {
                _singleCards[(int)cardPos] = null;

            }
            else if (cardPos is CardPosition.Central)
            {
                _centralStack.Pop();
            }
            else if (cardPos is CardPosition.Reserve)
            {
                _reserveStack.Pop();
            }

            UpdateCardTo(cardPos);
        }

        private void Remove(params CardPosition[] cardPositions)
        {
            foreach (var position in cardPositions)
            {
                Remove(position);
            }
        }

        private void UpdateCardTo(CardPosition cardPos)
        {
            CrossroadsCard? bufferCard = null;

            if (cardPos is CardPosition.Top or CardPosition.Right or CardPosition.Bottom or CardPosition.Left)
            {
                if (_centralStack.TryPop(out bufferCard))
                {
                    _singleCards[(int)cardPos] = bufferCard;
                }
                else
                {
                    if (_reserveStack.TryPop(out bufferCard))
                    {
                        _singleCards[(int)cardPos] = bufferCard;
                    }

                    if (_reserveStack.TryPop(out bufferCard))
                    {
                        _centralStack.Push(bufferCard);
                    }
                }
            }
            else if (cardPos is CardPosition.Central && _reserveStack.TryPop(out bufferCard))
            {
                _centralStack.Push(bufferCard);
            }
        }

        #endregion
    }
}
