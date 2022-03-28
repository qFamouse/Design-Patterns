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

        public bool isGameOver => _cardWorker.DeckSize + 1 <= 0;

        public SolitaireCrossroads()
        {
            _cardWorker = new CrossroadsCardWorker();
        }

        public void NewGame() => _cardWorker.NewGame();

        public bool TryParceCoupleCards(CardPosition a, CardPosition b) => _cardWorker.TryParceCoupleCards(a, b);

        public override string ToString()
        {
            string PeekCard(CardPosition cardType) => _cardWorker.TryPeekCard(cardType, out CrossroadsCard? card) ? card.ToString() : String.Empty;

            return
                $"{PeekCard(CardPosition.Top), 16}\n" +
                $"{PeekCard(CardPosition.Reserve)}{PeekCard(CardPosition.Left),7}{PeekCard(CardPosition.Central),7}{PeekCard(CardPosition.Right), 5}\n" +
                $"{PeekCard(CardPosition.Bottom), 16}\n";
        }
    }
}