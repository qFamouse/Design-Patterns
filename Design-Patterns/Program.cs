using System;
using System.Text;
using DesignPatterns.GRASP.Solitaire.Core.Extensions;
using DesignPatterns.GRASP.Solitaire.Core.Interfaces;
using DesignPatterns.GRASP.Solitaire.Crossroads;
using DesignPatterns.Tests.SOLID;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            SolitaireCrossroads solitaire = new SolitaireCrossroads();

            solitaire.GameInit();

            Console.WriteLine(solitaire.ToString());
        }
    }
}