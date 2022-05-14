using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.Products
{
    public enum KeyboardType
    {
        Regular, 
        Multimedia
    }
    public class Keyboard : BaseProduct
    {
        public override string Category => "Input devices";
        public KeyboardType KeyboardType { get; set; }

        public Keyboard(string name, int article, int price, KeyboardType keyboardType) : base(name, article, price)
        {
            KeyboardType = keyboardType;
        }

        public override string ToString()
        {
            return base.ToString() + $"KeyboardType: {KeyboardType}";
        }
    }
}
