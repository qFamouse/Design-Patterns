using DesignPatterns.Structural.Composite;
using DesignPatterns.Structural.Composite.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Tests.Structural
{
    internal static class Composite
    {
        private static List<IProduct> LoadProducts()
        {
            Processor processor = new Processor("Red Processor", 1, 134, "3.4hz", 4, "v2");
            RAM ram = new RAM("Blue RAM", 2, 163, 8000);
            GraphicCard graphicCard = new GraphicCard("Pink Card", 3, 731, true, 4000);
            HardDrive hardDrive = new HardDrive("Silver Drive", 4, 412, 1024, 7000);
            Motherboard motherboard = new Motherboard("Brown Motherboard", 5, 723, true, 52, "Rare Factor");
            Case @case = new Case("Black Case", 6, 100, 450, CaseType.Desktop);
            Screen screen = new Screen("Green Screen", 7, 426, 20, "10:9");
            Mouse mouse = new Mouse("Gold Mouse", 8, 60, 5);
            Keyboard keyboard = new Keyboard("Yellow Keyboard", 9, 140, KeyboardType.Regular);

            SystemBlock systemBlock = new SystemBlock("Gray Block", 10, @case, motherboard, processor, ram, hardDrive, graphicCard);
            PersonalComputer personalComputer = new PersonalComputer("Orange PC", 11, systemBlock, screen, keyboard, mouse);

            return new List<IProduct>()
            {
                processor, ram, graphicCard, hardDrive, motherboard, @case, screen, mouse, keyboard, systemBlock, personalComputer
            };
        }

        public static void Test()
        {
            List<IProduct> products = LoadProducts();
            products.Sort((x, y) => x.Price.CompareTo(y.Price));

            products.ForEach(p => Console.WriteLine(p + "\n"));
        }
    }
}
