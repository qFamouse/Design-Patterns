using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite
{
    public abstract class BaseProduct : IProduct
    {
        public abstract string Category { get; }
        public string Name { get; set; }
        public int Article { get; init; }
        public int Price { get; set; }

        public BaseProduct(string name, int article, int price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Article = article;
            Price = price;
        }

        public override string ToString()
        {
            return $"Name: {Name} | Category: {Category} | Article: {Article} | Price: {Price} | ";
        }
    }
}