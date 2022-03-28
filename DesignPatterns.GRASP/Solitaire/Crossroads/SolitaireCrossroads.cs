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
        private CrossroadsCardWorker _cardWorker;

        public bool isGameOver => _cardWorker.DeckSize <= 0;

        public SolitaireCrossroads()
        {
            _cardWorker = new CrossroadsCardWorker();
        }

        public void NewGame() => _cardWorker.NewGame();

        public void testc(CardPosition a, CardPosition b) => _cardWorker.TryRemoveCoupleCards(a, b);

        public override string ToString()
        {
            string PeekCard(CardPosition cardType) => _cardWorker.TryPeekCard(cardType, out CrossroadsCard? card) ? card.ToString() : String.Empty;

            return
                $"{PeekCard(CardPosition.Top), 15}\n" +
                $"{PeekCard(CardPosition.Reserve)}{PeekCard(CardPosition.Left),8}{PeekCard(CardPosition.Central),5}{PeekCard(CardPosition.Right), 5}\n" +
                $"{PeekCard(CardPosition.Bottom), 15}\n";
        }
    }
}