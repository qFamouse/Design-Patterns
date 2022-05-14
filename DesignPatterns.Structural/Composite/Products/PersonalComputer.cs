using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.Products
{
    public class PersonalComputer : IProduct
    {
        public string Category => "Personal computer";
        public string Name { get; set; }
        public int Article { get; init; }
        public int Price
        {
            get
            {
                const float allowance = 0.5f;
                int totalSum = SystemBlock.Price + Screen.Price + Keyboard.Price + Mouse.Price;
                return (int)(totalSum * allowance);
            }
        }

        SystemBlock SystemBlock { get; set; }
        Screen Screen { get; set; }
        Keyboard Keyboard { get; set; }
        Mouse Mouse { get; set; }

        public PersonalComputer(string name, int article, SystemBlock systemBlock, Screen screen, Keyboard keyboard, Mouse mouse)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Article = article;
            SystemBlock = systemBlock ?? throw new ArgumentNullException(nameof(systemBlock));
            Screen = screen ?? throw new ArgumentNullException(nameof(screen));
            Keyboard = keyboard ?? throw new ArgumentNullException(nameof(keyboard));
            Mouse = mouse ?? throw new ArgumentNullException(nameof(mouse));
        }

        public override string ToString()
        {
            return $"{Category} : {Name} : Price: {Price} (Article: {Article})" +
                $"\n\t{SystemBlock}" +
                $"\n\t{Screen}" +
                $"\n\t{Keyboard}" +
                $"\n\t{Mouse}";
        }
    }
}