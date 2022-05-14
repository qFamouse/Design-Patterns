using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.Products
{
    public class GraphicCard : BaseProduct
    {
        public override string Category => "Graphics card";
        public bool IsActiveCoolinng { get; set; }
        public int MemoryCapacity { get; set; }

        public GraphicCard(string name, int article, int price, bool isActiveCoolinng, int memoryCapacity) : base(name, article, price)
        {
            IsActiveCoolinng = isActiveCoolinng;
            MemoryCapacity = memoryCapacity;
        }

        public override string ToString()
        {
            return base.ToString() + $"ActiveCoolinng: {(IsActiveCoolinng is true ? "yes" : "no")} | MemoryCapacity: {MemoryCapacity}";
        }
    }
}