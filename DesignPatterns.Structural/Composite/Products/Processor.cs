using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.Products
{
    public class Processor : BaseProduct
    {
        public override string Category => "Processor";
        public string ProcessorSpeed { get; set; }
        public int Cores { get; set; }
        public string FormFactor { get; set; }

        public Processor(string name, int article, int price, string processorSpeed, int cores, string formFactor) : base(name, article, price)
        {
            ProcessorSpeed = processorSpeed ?? throw new ArgumentNullException(nameof(processorSpeed));
            Cores = cores;
            FormFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor));
        }

        public override string ToString()
        {
            return base.ToString() + $"ProcessorSpeed: {ProcessorSpeed} | Cores: {Cores} | FormFactor: {FormFactor}";
        }
    }
}