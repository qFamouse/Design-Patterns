using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.Products
{
    public class Mouse : BaseProduct
    {
        public override string Category => "Input devices";
        public int MouseButtons { get; set; }

        public Mouse(string name, int article, int price, int mouseButtons) : base(name, article, price)
        {
            MouseButtons = mouseButtons;
        }

        public override string ToString()
        {
            return base.ToString() + $"MouseButtons: {MouseButtons}";
        }
    }
}
