using Solitaire = DesignPatterns.GRASP.Solitaire.Crossroads.SolitaireCrossroads;
using System;
using System.Text;
using DesignPatterns.GRASP.Solitaire.Crossroads;

namespace DesignPatterns.Tests.GRASP
{
    internal static class SolitaireCrossroads
    {
        private static int CardPositionCount = Enum.GetValues(typeof(CardPosition)).Length;

        private static void ShowCardKeymap()
        {
            Console.WriteLine($"{(int)CardPosition.Top,16}\n" +
                $"{(int)CardPosition.Reserve}{(int)CardPosition.Left,8}{(int)CardPosition.Central,7}{(int)CardPosition.Right,5}\n" +
                $"{(int)CardPosition.Bottom,16}\n");
        }

        private static int ReadIntKey()
        {
            bool isInt = false;
            int parseInt = 0;

            while (!isInt)
            {
                string key = Console.ReadKey().KeyChar.ToString();
                isInt = Int32.TryParse(key, out parseInt);
            }

            return parseInt;
        }

        private static CardPosition ReadCardPosition()
        {
            int key;

            do
            {
                key = ReadIntKey();
                
            }
            while (key < 0 || key >= CardPositionCount);

            return (CardPosition) key;
        }

        public static void Test()
        {



            Console.OutputEncoding = Encoding.UTF8; // for unicode

            Solitaire solitaire = new Solitaire();
            solitaire.NewGame();

            do
            {
                Console.Clear();
                ShowCardKeymap();
                Console.WriteLine(solitaire.ToString());

                CardPosition cardPosA = ReadCardPosition();
                CardPosition cardPosB = ReadCardPosition();

                solitaire.TryParceCoupleCards(cardPosA, cardPosB);
            }
            while (!solitaire.isGameOver);
        }
    }
}
