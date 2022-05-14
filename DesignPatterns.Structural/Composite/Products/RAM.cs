using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.Products
{
    public class RAM : BaseProduct
    {
        public override string Category => "RAM";
        public int MbSize { get; set; }

        public RAM(string name, int article, int price, int mbSize) : base(name, article, price)
        {
            MbSize = mbSize;
        }

        public override string ToString()
        {
            return base.ToString() + $"MbSize: {MbSize}";
        }
    }
}
