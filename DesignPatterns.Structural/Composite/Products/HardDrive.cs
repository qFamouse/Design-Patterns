using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.Products
{
    public class HardDrive : BaseProduct
    {
        public override string Category => "Hard drive";
        public int GbSize { get; set; }
        public int SpindleRotationSpeed { get; set; }

        public HardDrive(string name, int article, int price, int gbSize, int spindleRotationSpeed) : base(name, article, price)
        {
            GbSize = gbSize;
            SpindleRotationSpeed = spindleRotationSpeed;
        }

        public override string ToString()
        {
            return base.ToString() + $"GbSize: {GbSize} | SpindleRotationSpeed: {SpindleRotationSpeed}";
        }
    }
}