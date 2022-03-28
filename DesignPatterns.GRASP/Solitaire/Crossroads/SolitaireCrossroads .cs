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

        public SolitaireCrossroads()
        {
            _cardWorker = new CrossroadsCardWorker();
        }

        public void NewGame() => _cardWorker.NewGame();

        public void testc(CardType a, CardType b) => _cardWorker.TryRemoveCoupleCards(a, b);

        public override string ToString()
        {
            string PeekCard(CardType cardType) => _cardWorker.TryPeekCard(cardType, out CrossroadsCard? card) ? card.ToString() : String.Empty;

            return
                $"{PeekCard(CardType.Top), 15}\n" +
                $"{PeekCard(CardType.Reserve)}{PeekCard(CardType.Left),8}{PeekCard(CardType.Central),5}{PeekCard(CardType.Right), 5}\n" +
                $"{PeekCard(CardType.Bottom), 15}\n";
        }
    }
}
