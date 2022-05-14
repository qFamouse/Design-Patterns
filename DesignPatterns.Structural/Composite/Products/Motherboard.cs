using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.Products
{
    public class Motherboard : BaseProduct
    {
        public override string Category => "Motherboard";
        public bool BuiltCard { get; set; }
        public int MaxRam { get; set; }
        public string FormFactor { get; set; }

        public Motherboard(string name, int article, int price, bool builtCard, int maxRam, string formFactor) : base(name, article, price)
        {
            BuiltCard = builtCard;
            MaxRam = maxRam;
            FormFactor = formFactor;
        }

        public override string ToString()
        {
            return base.ToString() + $"ProcessorSpeed: {(BuiltCard is true ? "yes" : "no")} | MaxRam: {MaxRam} | FormFactor: {FormFactor}";
        }
    }
} 