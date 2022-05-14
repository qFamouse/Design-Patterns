using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.Products
{
    public class Screen : BaseProduct
    {
        public override string Category => "Screen";
        public int DiagonalSize { get; set; }
        public string AspectRatio { get; set; }

        public Screen(string name, int article, int price, int diagonalSize, string aspectRatio) : base(name, article, price)
        {
            DiagonalSize = diagonalSize;
            AspectRatio = aspectRatio;
        }

        public override string ToString()
        {
            return base.ToString() + $"DiagonalSize: {DiagonalSize} | AspectRatio: {AspectRatio}";
        }
    }
}